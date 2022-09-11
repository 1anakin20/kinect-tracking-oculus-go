using System.Net;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class IPText : MonoBehaviour
{
    [SerializeField] private TextMeshPro mObject;
    
    // Start is called before the first frame update
    void Start()
    {
        mObject.text = GetLocalIPAddress();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "No IP";
    }
}