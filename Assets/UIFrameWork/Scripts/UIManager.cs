using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UI_instance;

    private Dictionary<string, string> pathDic;
    private Dictionary<string, GameObject> prefabsDic;
    public Dictionary<string, BasePanel> panelDic;

    private Transform UI_root;
    public static UIManager UI_Inatance
    {
        get
        {

            if (UI_instance == null)
                UI_instance = new UIManager();

            return UI_instance;
        }
    }

    public Transform UI_Root
    {
        get
        {
            if (UI_root == null)
                UI_root = GameObject.Find("Canvas").transform;

            return UI_root;
        }

    }

    /// <summary>
    /// 构造函数，初始化字典
    /// </summary>
    private UIManager()
    {
        InitDic();
    }

    /// <summary>
    /// 初始化路径字典
    /// </summary>
    private void InitDic()
    {
        prefabsDic = new Dictionary<string,GameObject>();
        panelDic = new Dictionary<string, BasePanel>();

        pathDic = new Dictionary<string, string>()
        {
            {UIContent.MainMenuPanel,"UIFrameWork/PanelPrefabs/MainMenuPanel" },
            {UIContent.PausePanel,"UIFrameWork/PanelPrefabs/PausePanel" },
            {UIContent.SettingPanel,"UIFrameWork/PanelPrefabs/SettingPanel" },
        };
    }


    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        //Check whether target panel is opened
        if (panelDic.TryGetValue(name,out panel))
        {
            Debug.Log("Panel is already opend");
            return null;
        }
        //Check whether path is setting
        string path = "";
        if(!pathDic.TryGetValue(name, out path))
        {
            Debug.Log("False panel name:"+path);
            return null;
        }

        //find the prefab panel
        GameObject panelPrefab = null;
        if(!prefabsDic.TryGetValue(name,out panelPrefab))
        {
            string realPath = "Prefabs/UI/Panel/"+path;
            panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
            prefabsDic.Add(name, panelPrefab);
        }
        GameObject panelObject = Instantiate(panelPrefab,UI_Root,false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDic.Add(name, panel);
        return panel;
    }

    public bool ClosePanel(string name)
    {
        BasePanel panel = null;
        if(!panelDic.TryGetValue(name,out panel))
        {
            Debug.Log("Panel is not open:" + name);
            return false;
        }

        panel.ClosePanel(name);
        return true;
    }
}

public class UIContent
{
    public const string MainMenuPanel = "MainMenuPanel";

    public const string PausePanel = "PausePanel";

    public const string SettingPanel = "SettingPanel";
}

