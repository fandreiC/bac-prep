namespace BacPrep.Modules.Content;

public enum SessionType
{
    Summer,
    Autumn,
    Special,
    NationalSimulation,
    RegionalSimulation,
    OfficialModel
}

public sealed record DisciplineDto(int Id, string Name);

public sealed record SyllabusDto(int Id, int DisciplineId, string Profile);

public sealed record TestSummaryDto(int Id, int SyllabusId, int Year, SessionType Session, int Variant);