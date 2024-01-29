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

public class ObjectCreation : BaseNetLogic
{
    [ExportMethod]
    public void CreateObjects()
    {
        // Create Base folder
        var objectsFolder = InformationModel.MakeObject<Folder>("Objectsçãçã");
        Project.Current.Add(objectsFolder);

        // InformationModel.MakeObject(browseName) Test Step
        var motorObject = InformationModel.MakeObject("MotorObjectçãçã");
        objectsFolder.Add(motorObject);

        // InformationModel.MakeObjectType(browseName) Test Step
        var motorType = InformationModel.MakeObjectType("Motor1çãçã");
        objectsFolder.Add(motorType);

        // InformationModel.MakeObject(browseName, objectTypeId) Test Step
        var mymotor = InformationModel.MakeObject("NewMotorçãçã", motorType.NodeId);
        objectsFolder.Add(mymotor);

        // InformationModel.MakeObjectType(browseName, superTypeId) Test Step
        var supertype = Project.Current.Find("Motor1çãçã");
        objectsFolder.Add(InformationModel.MakeObjectType("SpecialMotorçãçã", supertype.NodeId));

        // InformationModel.MakeObjectType<T>(browseName) Test Step
        var newLabelType= InformationModel.MakeObjectType<LabelType>("NewLabelType");
        objectsFolder.Add(newLabelType);
    }

    [ExportMethod]
    public void CleanUp()
    {
        Owner.Get("Objects").Delete();
    }

}
