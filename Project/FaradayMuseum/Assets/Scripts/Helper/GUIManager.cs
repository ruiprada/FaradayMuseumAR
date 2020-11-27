using System.Collections.Generic;

internal static class GUIManager
{
   private static Dictionary<string, GUIControl> m_Controls = new Dictionary<string, GUIControl>();
 
   public static void Register(GUIControl pControl)
   {
     if (pControl != null && !m_Controls.ContainsKey(pControl.Name))
     {
       m_Controls.Add(pControl.Name, pControl);
     }
   }
 
   public static void Unregister(GUIControl pControl)
   {
     if (pControl != null)
     {
       m_Controls.Remove(pControl.Name);
     }
   }
 
   public static void Show(string pControlName)
   {
     GUIControl result = null;
     if (m_Controls.TryGetValue(pControlName, out result) && !result.gameObject.activeSelf)
     {
       result.OnShow();
     }
   }
 
   public static void ShowAndHide(string pControlName, GUIControl pToHide)
   {
     if (pControlName == pToHide.Name)
     {
       return;
     }
     GUIControl result = null;
     if (m_Controls.TryGetValue(pControlName, out result))
     {
       if (!result.gameObject.activeSelf) result.OnShow();
       if (pToHide.gameObject.activeSelf) pToHide.OnHide();
     }
   }
 
   public static void Hide(string pControlName)
   {
     GUIControl result = null;
     if (m_Controls.TryGetValue(pControlName, out result) && result.gameObject.activeSelf)
     {
       result.OnHide();
     }
   }
}