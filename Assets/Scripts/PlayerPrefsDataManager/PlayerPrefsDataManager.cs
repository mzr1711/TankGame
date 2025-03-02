using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.LightingExplorerTableColumn;

/// <summary>
/// PlayerPrefs���ݹ����࣬ͳһ�������ݵĶ�ȡ�ʹ洢
/// </summary>
public class PlayerPrefsDataManager
{
    private static PlayerPrefsDataManager instance = new PlayerPrefsDataManager();

    public static PlayerPrefsDataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerPrefsDataManager()
    {

    }

    /// <summary>
    /// �洢����
    /// </summary>
    /// <param name="data">���ݶ���</param>
    /// <param name="keyName">���ݶ���Ψһ��key �Լ�����</param>
    public void SaveData(object data, string keyName)
    {
        Type dataType = data.GetType();
        FieldInfo[] infos = dataType.GetFields();
        // keyName_��������_�ֶ�����_�ֶ���
        string saveName = "";
        for (int i = 0; i < infos.Length; i++)
        {
            saveName = keyName + "_" + dataType.Name + "_" +
                infos[i].FieldType.Name + "_" + infos[i].Name;
            SaveValue(infos[i].GetValue(data), saveName);
        }
        PlayerPrefs.Save();
    }

    private void SaveValue(object saveData, string saveName)
    {
        Type t = saveData.GetType();
        if (t == typeof(int))
        {
            PlayerPrefs.SetInt(saveName, (int)saveData);
        }
        else if (t == typeof(float))
        {
            PlayerPrefs.SetFloat(saveName, (float)saveData);
        }
        else if (t == typeof(string))
        {
            PlayerPrefs.SetString(saveName, saveData.ToString());
        }
        else if (t == typeof(bool))
        {
            PlayerPrefs.SetInt(saveName, (bool)saveData == true ? 1 : 0);
        }
        // ͨ�������жϸ��ӹ�ϵ
        else if (typeof(IList).IsAssignableFrom(t))
        {
            IList iList = saveData as IList;
            PlayerPrefs.SetInt(saveName, iList.Count);
            for (int i = 0; i < iList.Count; i++)
            {
                SaveValue(iList[i], saveName + i);
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(t))
        {
            IDictionary iDic = saveData as IDictionary;
            PlayerPrefs.SetInt(saveName, iDic.Count);
            int index = 0;
            foreach (object key in iDic.Keys)
            {
                SaveValue(key, saveName + "_key_" + index);
                SaveValue(iDic[key], saveName + "_value_" + index);
                index++;
            }
        }
        else if (t.GetType().IsClass)
        {
            SaveData(t, saveName);
        }
    }

    /// <summary>
    /// ��ȡ����
    /// </summary>
    /// <param name="type">��Ҫ��ȡ����� ��������</param>
    /// <param name="keyName">���ݶ����Ψһkey �Լ�����</param>
    /// <returns>���ش����õĶ���</returns>
    public object LoadData(Type type, string keyName)
    {
        // ����object���󣬶�ʹ��type����
        // Ŀ����Ϊ�˽�ʡһ�δ�������Ĵ���
        // �����object���룬��ȡһ��Player���͵����ݣ��ͱ������ⲿnewһ��������
        // ��type����Ļ����Ϳ���ֻ����type typeof(Player)�������ڲ�����һ�����󷵻س���
        object data = Activator.CreateInstance(type);
        FieldInfo[] infos = type.GetFields();
        string getName = "";
        for(int i = 0; i < infos.Length; i++)
        {
            getName = keyName + "_" + type.Name + "_" +
                infos[i].FieldType.Name + "_" + infos[i].Name;
            infos[i].SetValue(data, LoadValue(infos[i].FieldType, getName));
        }

        return data;
    }

    private object LoadValue(Type type, string getName)
    {
        if (type == typeof(int))
        {
            return PlayerPrefs.GetInt(getName);
        }
        else if(type == typeof(float))
        {
            return PlayerPrefs.GetFloat(getName);
        }
        else if(type == typeof(string))
        {
            return PlayerPrefs.GetString(getName);
        }
        else if(type == typeof(bool))
        {
            return PlayerPrefs.GetInt(getName) == 1 ? true : false;
        }
        else if(typeof(IList).IsAssignableFrom(type))
        {
            int count = PlayerPrefs.GetInt(getName);
            IList iList = Activator.CreateInstance(type) as IList;
            for (int i = 0; i < count; i++)
            {
                iList.Add(LoadValue(type.GetGenericArguments()[0], getName + i));
            }
            return iList;
        }
        else if(typeof(IDictionary).IsAssignableFrom(type))
        {
            int count = PlayerPrefs.GetInt(getName);
            IDictionary iDic = Activator.CreateInstance(type) as IDictionary;
            for(int i = 0; i < count; i++)
            {
                iDic.Add(LoadValue(type.GetGenericArguments()[0], getName + "_key_" + i),
                    LoadValue(type.GetGenericArguments()[1], getName + "_value_" + i));
            }
            return iDic;
        }
        else if(type.IsClass)
        {
            return LoadData(type, getName);
        }

        return null;
    }
}

