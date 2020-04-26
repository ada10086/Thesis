using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DebugStuff{

public class ConsoleToGUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static string myLog = "";
    private string output;
    private string stack;
 
    void OnEnable()
         {
             Application.logMessageReceived += Log;
         }
 
    void OnDisable()
         {
             Application.logMessageReceived -= Log;
         }
 
    public void Log(string logString, string stackTrace, LogType type)
         {
             output = logString;
             stack = stackTrace;
             myLog = output + "\n" + myLog;
             if (myLog.Length > 5000)
             {
                 myLog = myLog.Substring(0, 4000);
             }
         }
 
    void OnGUI()
         {
             //if (!Application.isEditor) //Do not display in editor ( or you can use the UNITY_EDITOR macro to also disable the rest)
             {
                 myLog = GUI.TextArea(new Rect(10, 10, Screen.width - 10, Screen.height - 10), myLog);
             }
         }
}
}
    
