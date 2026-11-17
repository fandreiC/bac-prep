namespace BacPrep.Modules.Content;

public sealed class InMemoryContentStore
{
    public IReadOnlyList<DisciplineDto> Disciplines {get;}=
    [
        new(1, "Matematică"),
        new(2, "Limba si literatura română"),
        new(3, "Informatică"),
    ];

    private readonly List<SyllabusDto> _syllabi =
    [
        new(1, 1, "Mate-Info"),
        new(2, 1, "Științe ale naturii"),
        new(3, 2, "Real"),
        new(4, 2, "Uman"),
        new(5, 3, "Mate-Info"),
    ];

    private readonly List<TestSummaryDto> _tests =
    [
      new(1, 1, 2026, SessionType.Summer, 3),
      new(2, 1, 2026, SessionType.NationalSimulation, 1),
      new(3, 5, 2026, SessionType.Summer, 3)
    ];

    public bool DisciplineExists(int id) => Disciplines.Any(d => d.Id == id);
    public bool SyllabusExists(int id) => _syllabi.Any(s => s.Id == id);
    public IReadOnlyList<SyllabusDto> GetSyllabi(int disciplineId) =>
        _syllabi.Where(s => s.DisciplineId == disciplineId).ToList();
    public IReadOnlyList<TestSummaryDto> GetTests(int syllabusId) =>
        _tests.Where(t => t.SyllabusId == syllabusId).ToList();

    

}