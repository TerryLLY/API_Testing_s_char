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

public class ReadWriteFieldVariables : BaseNetLogic
{
    [ExportMethod]
    public void ReadWriteVariables()
    {
        // Setup
        // Create Model Folder
        var modelFolder = InformationModel.MakeObject<Folder>("Model");
        Project.Current.Add(modelFolder);
        // Create Motor type
        var motorType = InformationModel.MakeObjectType("Motor");
        modelFolder.Add(motorType);
        motorType.Add(InformationModel.MakeVariable("Speed", OpcUa.DataTypes.Int32));
        motorType.Add(InformationModel.MakeVariable("Acceleration", OpcUa.DataTypes.Int32));

        // IUAVariable.RemoteRead(timeoutMilliseconds) Test Step
        var currentSpeed = Project.Current.GetVariable("Model/Motor/Speed");
        var value = currentSpeed.RemoteRead();
        Log.Info("Current Speed is: " + value.ToString());

        // IUAVariable.RemoteWrite(value, timeoutMilliseconds) Test Step
        currentSpeed.RemoteWrite(42);
        value = currentSpeed.RemoteRead();
        Log.Info("Current Speed is now: " + value.ToString());

        // InformationModel.RemoteRead(variables, timeoutMilliseconds) Test Step

        // InformationModel.RemoteWrite(variableValues, timeoutMilliseconds) Test Step

        // IUANode.ChildrenRemoteRead(timeoutMilliseconds) Test Step

        // IUANode.ChildrenRemoteRead(childVariables, timeoutMilliseconds) Test Step

        // IUANode.ChildrenRemoteWrite(childVariableValues, timeoutMilliseconds) Test Step
    }

    [ExportMethod]
    public void CleanUp()
    {
        Owner.Get("Model").Delete();
    }
}
