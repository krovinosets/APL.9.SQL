namespace DatabaseModels;

public class Certificate : ITable
{
    public uint Id { get; set; }
    public uint DoctorId { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Doctor Doctor { get; set; }

    public Certificate(uint doctorId, string description, DateTime date, Doctor doctor)
    {
        DoctorId = doctorId;
        Description = description;
        Date = date;
        Doctor = doctor;
    }
    
    public Certificate(){ }
    
    public override string ToString()
    {
        return $$"""{Certificate record: [ID: {{Id}}, """ +
               $$"""Doctor ID: {{DoctorId}}, """ +
               $$"""Description: {{Description}}, """ +
               $$"""Date: {{Date}}, """ +
               $$"""Doctor: {{Doctor}}]}""";
    }
}