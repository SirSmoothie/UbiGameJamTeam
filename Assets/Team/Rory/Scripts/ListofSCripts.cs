using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class tTrailt
{
    public string nameof;
    public bool isitbad;
    public int IntforImage;
}
[Serializable]
public class tHEadt
{
    public string nameof;
    public bool isitbad;
    public int IntforImage;
}
[Serializable]
public class tFint
{
    public string nameof;
    public bool isitbad;
    public int IntforImage;
}

public class ListofSCripts : MonoBehaviour
{
    public tTrailt Tail;
    public tHEadt Head;
    public tFint fin;
}
