using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalCameraController : Singleton<GlobalCameraController>
{
    [SerializeField] private List<CinemachineVirtualCamera> cameras =  new List<CinemachineVirtualCamera>();

    public void CallCam(string camName)
    {
        for(int i =0;i < cameras.Count; i++)
        {
            cameras[i].m_Priority = 0;
        }

        CinemachineVirtualCamera selectCam = cameras.Where(x => x.name == camName).First();

        selectCam.Priority = 1;
    }
}
