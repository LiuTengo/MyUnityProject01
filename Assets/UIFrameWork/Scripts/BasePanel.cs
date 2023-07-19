using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 用法：在面板预制体中挂载该父类的子类。调用其他面板时，使用UIManager.UI_Instance.OpenPanel(UIConst.。。。),关闭时同理；
/// 注意：新添加的面板需要在UIManager中更新字典，同时确保路径的正确
/// </summary>
public class BasePanel : MonoBehaviour
{

    protected bool isRemoved = false;//wheter panel is removed
    protected string panelName;//record panel name

    /// <summary>
    /// Open a new panel
    /// </summary>
    /// <param name="name"></param>
    public virtual void OpenPanel(string name)
    {
        panelName = name;
        gameObject.SetActive(true);
    }
    /// <summary>
    /// Destroy an already existed panel 
    /// </summary>
    /// <param name="name"></param>
    public virtual void ClosePanel(string name)
    {
        isRemoved = true;
        gameObject.SetActive(false);
        Destroy(gameObject);

        //Remove panel buffer
        if (UIManager.UI_Inatance.panelDic.ContainsKey(name))
        {
            UIManager.UI_Inatance.panelDic.Remove(name);
        }
    }


}
