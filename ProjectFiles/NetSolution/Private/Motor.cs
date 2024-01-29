using System;
using UAManagedCore;

//-------------------------------------------
// WARNING: AUTO-GENERATED CODE, DO NOT EDIT!
//-------------------------------------------

[MapType(NamespaceUri = "API_Testing_s_char", Guid = "50ff94ca9e12d84b82fddfbb810415cf")]
public class Motor : UAObject
{
#region Children properties
    //-------------------------------------------
    // WARNING: AUTO-GENERATED CODE, DO NOT EDIT!
    //-------------------------------------------
    public int Speed
    {
        get
        {
            return (int)Refs.GetVariable("Speed").Value.Value;
        }
        set
        {
            Refs.GetVariable("Speed").SetValue(value);
        }
    }
    public IUAVariable SpeedVariable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Speed");
        }
    }
    public int Acceleration
    {
        get
        {
            return (int)Refs.GetVariable("Acceleration").Value.Value;
        }
        set
        {
            Refs.GetVariable("Acceleration").SetValue(value);
        }
    }
    public IUAVariable AccelerationVariable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Acceleration");
        }
    }
#endregion
}
