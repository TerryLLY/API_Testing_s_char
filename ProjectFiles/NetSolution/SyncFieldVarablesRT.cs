#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.UI;
using FTOptix.CODESYS;
using FTOptix.NativeUI;
#endregion

public class SyncFieldVarablesRT : BaseNetLogic
{
    public override void Start()
    {


        motorSpeed = LogicObject.Owner.GetVariable("StaticObjects/Motor/Speed");
        variableSynchronizer = new RemoteVariableSynchronizer();
        variableSynchronizer.Add(motorSpeed);
        motorSpeed.VariableChange += MotorSpeed_VariableChange;
    }
    private void MotorSpeed_VariableChange(object sender, VariableChangeEventArgs e) {
        if (motorSpeed.Value > 200) {
            Log.Warning("Speed limit reached!");
        }
    }
    private IUAVariable motorSpeed;
    private RemoteVariableSynchronizer variableSynchronizer;
    

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
}
