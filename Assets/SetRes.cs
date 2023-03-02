using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetRes : MonoBehaviour
{
    private Dropdown dropdown;
    private Resolution[] res;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        res = Screen.resolutions;
        List<string> dropOptions = new List<string>();
        int i = 0;
        int pos = 0;
        Resolution currRes = Screen.currentResolution;
        foreach (Resolution r in res)
        {
            string val = r.ToString();
            dropOptions.Add(val);
            if (r.width == currRes.width &&
                r.height == currRes.height &&
                r.refreshRate == currRes.refreshRate)
            {
                pos = i;
            }
            i++;
        }
        dropdown.AddOptions(dropOptions);
        dropdown.value = pos;
    }

    public void SetResolution()
    {
        Resolution r = res[dropdown.value];
        Screen.SetResolution(r.width, r.height, Screen.fullScreenMode, r.refreshRate);
    }
}
