# Ubiquitous language: Bac Prep glossary

One meaning per word, used the same way in conversations, docs, code and the UI.
Code uses the **English term**; the UI shown to students uses the **Romanian term**.

Rules:
- If a word is not here and we need it, add it here first, then use it in code.
- If two words mean the same thing, pick one and list the other under "Words to avoid".
- Last updated: 2026-11-14 (added Bac, AnswerKey, BaremItem groups, GeneralNotes; aligned session and exercise types)

## Exam domain (how the real Bacalaureat works)

| Term (code) | Romanian (UI) | Meaning | Notes |
| --- | --- | --- | --- |
| Bac | Bac | Short for Bacalaureat. Use it everywhere: conversations, docs, code (e.g. BacPrep) and UI | Never "BAC" or "Bacc" |
| Exam | Examen de bacalaureat | The national Bacalaureat exam as a whole | One per year, several sessions |
| WrittenExam | Probă scrisă | One written exam a student takes, e.g. E.a), E.c), E.d) | E.a) Romanian, E.c) mandatory discipline of the profile, E.d) elective of the profile |
| Discipline | Disciplină / materie | A school discipline: Math, Romanian language, Informatics | Not "Subject": see Words to avoid |
| Profile | Profil / specializare | The student's track. Decides which paper they get for a discipline | Math: Mate-Info, Științe ale naturii, Tehnologic, Pedagogic. Romanian: real, uman (to verify). Informatics: Mate-Info, Științe ale naturii; C/C++ or Pascal (to verify) |
| Syllabus | Programă | Chapters and theory of one Discipline for one Profile | Discipline + Profile = one Syllabus |
| Session | Sesiune | When a paper was given | See Session types below |
| Test | Subiect / variantă de examen | One complete exam paper for one Syllabus, one Year and one SessionType | Contains Sections; has Variant, DurationMinutes, IsReserve, GeneralNotes. Candidate rename: ExamPaper (open question) |
| Variant | Variantă | One of several papers prepared for a session; one is drawn on exam day | "Varianta extrasă" = the variant drawn |
| ReservePaper | Subiect de rezervă | Backup paper prepared for a session | Not a separate entity: a Test with IsReserve = true. Usable as extra practice |
| Section | Subiectul I / al II-lea / al III-lea | One part of a Test, with a Number (1, 2, 3) and MaxPoints | Every paper has 3 sections. A section can hold a single Exercise (e.g. the Romanian essay in Subiectul III) |
| Exercise | Item / exercițiu | One question inside a Section, with a Label (e.g. "3", "2.c", "A.4", "B") and MaxPoints | Tagged with exactly one Chapter |
| Barem | Barem de evaluare și de notare | Official scoring criteria and points for a Test | Kept as the Romanian word in code too |
| BaremItem | Criteriu din barem | One scoring criterion with its MaxPoints and Order. Always belongs to an Exercise, never to a Section | Used for self-grading. Complex rules (word minimums, error bands) stay in the Description text in v1 |
| BaremGroup | Conținut / Redactare | Optional label grouping BaremItems of one Exercise | Used by Romanian essays: Conținut (content) and Redactare (writing) |
| AnswerKey | Răspuns corect / cheie | The correct answer of a MultipleChoice, Numeric or CodeOutput Exercise, checked automatically | Not a BaremItem. E.g. Informatics "1c 2d 3b" |
| GeneralNotes | Precizări generale | Scoring rules for the whole Test | E.g. "any correct method is scored", "no fractions of a point" |
| OfficePoints | Puncte din oficiu | 10 points every candidate gets automatically | Max 90 + 10 = 100 |
| Grade | Notă | Total points divided by 10 (1.00 to 10.00) | |
| PassingRule | Promovare | Pass = at least 5 in each written exam and an overall average of at least 6 | |

Points must add up: BaremItems = their Exercise's MaxPoints; Exercises = their Section's MaxPoints; Sections = 90. Points are whole numbers only.

### Session types

Enum `SessionType` in code.

| Value (code) | Romanian (UI) | Meaning |
| --- | --- | --- |
| Summer | Sesiunea de vară (iunie-iulie) | Main session |
| Autumn | Sesiunea de toamnă (august) | Second chance session |
| Special | Sesiunea specială | Early session for olympiad participants and performance athletes |
| NationalSimulation | Simulare națională | National mock exam during the school year |
| RegionalSimulation | Simulare județeană | County-level mock exam |
| OfficialModel | Model oficial | Sample paper published before the exam year |

## Content module

| Term (code) | Romanian (UI) | Meaning |
| --- | --- | --- |
| Chapter | Capitol | A topic within a Syllabus, e.g. "Funcții", "Tablouri" |
| Theory | Teorie | Explanation of a Chapter |
| Solution | Rezolvare | Official or worked solution of an Exercise, as Steps |
| Step | Pas de rezolvare | One step in a Solution |
| ExerciseType | Tip de exercițiu | How an answer is checked. Enum values below |

ExerciseType values:

| Value (code) | Romanian (UI) | Checked by | Example |
| --- | --- | --- | --- |
| MultipleChoice | Grilă | AnswerKey, automatic | Informatics Subiectul I |
| Numeric | Rezultat numeric | AnswerKey on the final result; if wrong, SelfGrading on the steps | Math items |
| ShortAnswer | Răspuns scurt | SelfGrading with BaremItems | Romanian Subiectul I.A |
| CodeOutput | Ce se afișează? | AnswerKey, automatic | Informatics "what does this print?" |
| CodeWriting | Scriere de program | SelfGrading with the BaremItem checklist (no code execution in v1) | Informatics programs and subprograms |
| Essay | Eseu / text argumentativ | SelfGrading with BaremItems, grouped by BaremGroup | Romanian I.B, II, III |

## Practice module

| Term (code) | Romanian (UI) | Meaning |
| --- | --- | --- |
| PracticeMode | Exersare | Solve exercises freely, instant feedback, no timer |
| ExamMode | Simulare examen | Take a full Test under exam conditions: timer, no feedback until the end |
| Attempt | Încercare | One Student taking one Test (or one practice set) |
| Answer | Răspuns | A Student's response to one Exercise, with points earned |
| SelfGrading | Autoevaluare | Student scores their own essay using the BaremItems |
| Score | Punctaj | Points earned in an Attempt (0 to 100, including OfficePoints) |
| Progress | Progres | Scores over time, per Discipline and per Chapter |

## Students module

| Term (code) | Romanian (UI) | Meaning |
| --- | --- | --- |
| Student | Elev | A registered user preparing for the Bac |
| Parent | Părinte | Optional contact that receives the weekly ProgressReport. Not a user account in v1 |
| ProgressReport | Raport de progres | Weekly email summarising a Student's Progress |

## Words to avoid

| Avoid | Because | Use instead |
| --- | --- | --- |
| Subject | In English it means a discipline, but "subiect" in Romanian means an exam paper or a Section | Discipline |
| "subiect" in code | Means an exam paper or a Section in Romanian | Test or Section, whichever is meant |
| Exam (for one paper) | Exam is the whole Bacalaureat | Test |
| Quiz | Unclear size and rules | Test (official paper) or PracticeMode |
| User | Too generic | Student, Parent, Admin |
| Grade (for points) | Grade is points / 10 | Score |

## Open questions

- Rename Test to ExamPaper, to separate official papers from practice sets?
- Confirm the profiles for Romanian and Informatics on subiecte.edu.ro.
- Do Exercises link to the Theory a student needs (many-to-many)? v1 or later?
- Syllabus versioning per year (ValidFromYear, chapters on/off per year): v2.

## Sources

- Official papers and barems: Ministerul Educației / CNPEE, published on https://subiecte.edu.ro
- Session and profile names checked on https://subiectebac.ro/mate/mate_2026.html (2026-11-14). Barem structure checked on the 2026 summer barems for Math, Informatics and Romanian. That site republishes the official papers; its own text is not licensed for reuse.
