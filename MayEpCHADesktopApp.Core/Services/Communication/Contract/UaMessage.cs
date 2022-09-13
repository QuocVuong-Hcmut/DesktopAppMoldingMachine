namespace InjectionMoldingMachineDataAcquisitionService.Communication.Messages;
public class UaMessage
{
    public string MachineId { get; private set; }
    public string Name { get; private set; }
    public object Value { get; private set; }

    public UaMessage (string name,object value,string machineId)
    {
        Name=name;
        Value=value;
        MachineId=machineId;
    }
}
