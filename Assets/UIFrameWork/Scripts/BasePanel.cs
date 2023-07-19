using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �÷��������Ԥ�����й��ظø�������ࡣ�����������ʱ��ʹ��UIManager.UI_Instance.OpenPanel(UIConst.������),�ر�ʱͬ��
/// ע�⣺����ӵ������Ҫ��UIManager�и����ֵ䣬ͬʱȷ��·������ȷ
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
