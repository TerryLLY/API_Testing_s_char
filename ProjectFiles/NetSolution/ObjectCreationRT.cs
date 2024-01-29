#region Using directives
using System;
using System.Threading;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.CODESYS;
#endregion

public class ObjectCreationRT : BaseNetLogic
{
    public override void Start()
    {
        // InformationModel.MakeObject<T>(browseName) Test Step
        var objectsFolder = Project.Current.Get<Folder>("Objectsçãçã");
        var staticObjectsFolder = Project.Current.Get<Folder>("StaticObjects");
        var mainWindow = staticObjectsFolder.Get<WindowType>("MainWindow");
        var newMotor2 = InformationModel.MakeObject<Motor>("NewMotor2çãçã");
        newMotor2.Speed = 20;
        objectsFolder.Add(newMotor2);
        var label1 = InformationModel.MakeObject<Label>("Label1çãçã");
        label1.TopMargin = 10;
        label1.LeftMargin = 10;
        label1.Text = "NewMotor2 Speed Value:";
        mainWindow.Add(label1);

        var label2 = InformationModel.MakeObject<Label>("Label2çãçã");
        label2.TopMargin = 10;
        label2.LeftMargin = 150;
        label2.Text = "Empty (Failed)";
        mainWindow.Add(label2);
        label2.TextVariable.SetDynamicLink(newMotor2.SpeedVariable, DynamicLinkMode.ReadWrite);

        // InformationModel.MakeObject<T>(browseName, objectTypeId) Test Step
        var motortype = Project.Current.Find("Motor");
        var newMotor3 = InformationModel.MakeObject<Motor>("NewMotor3çãçã", motortype.NodeId);
        objectsFolder.Add(newMotor3);
        newMotor3.Speed = 500;
        var label3 = InformationModel.MakeObject<Label>("Label3çãçã");
        label3.TopMargin = 50;
        label3.LeftMargin = 10;
        label3.Text = "NewMotor3 Speed Value:";
        mainWindow.Add(label3);

        var label4 = InformationModel.MakeObject<Label>("Label4çãçã");
        label4.TopMargin = 50;
        label4.LeftMargin = 150;
        label4.Text = "Empty (Failed)";
        mainWindow.Add(label4);
        label4.TextVariable.SetDynamicLink(newMotor3.SpeedVariable, DynamicLinkMode.ReadWrite);

        // Nicola check out below...
        // // InformationModel.MakeObjectType<T>(browseName, superTypeId) Test Step
        // var supertype2 = Project.Current.Find("Motorçãçã");
        // objectsFolder.Add(InformationModel.MakeObjectType<MotorType>("NewMotorTypeçãçã", supertype2.NodeId));
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

}
