# Bac Prep
A web app that helps Romanian 12th-grade students prepare for the Bacalaureat
(Math, Romanian language, Informatics).

Status: in development.

## The problem
Students often face challenges such as a lack of clear structure, a heavy academic workload, and the high cost of private tutoring.
Key difficulties encountered by students:
- Lack of organization and procrastination
- Gaps in knowledge accumulated from previous years
- The high cost of private tutoring
- Anxiety regarding grading criteria and the required phrasing of answers

## Who it's for
- Primary user: students taking the Baccalaureate exam in Mathematics, Romanian Language, or Informatics, who are willing to use online resources.
- Secondary user (if any): the parents of these students.

## What v1 includes
- Sign-up and login for students (email and display name only)
- Browse subjects and past Bac papers; every exercise is tagged with its chapter
- Practice mode: solve exercises and get instant feedback
- Exam mode: a full simulated Bac paper with a timer
- Romanian essays: self-grading against the official barem, point by point
- Progress page: scores per subject and per chapter over time
- Weekly progress email to the student and, optionally, a parent
- Simple pages.

### How answers are checked in v1
| Subject | Checking |
| --- | --- |
| Math | Final numeric answer or multiple choice |
| Informatics | Multiple choice, "what does this code print?", short answers |
| Romanian | Multiple choice for subject I; self-grading with the barem for the essay |

## Out of scope for v1
- Add an AI engine.
- Load more information: add more tests from books (only where the licence allows it).
- Load more information: add more exercise types, not only final tests.
- Load even more information: until we have complete information for high-school years, 9-12.
- Update pages: from simple to more complex.
- Update exercise types: based on Ministry of Education’s requirements.
- Progress page: update parrent/sudent dashboard.
- Payments and subscriptions and donations.
- Running student code for Informatics (needs a secure sandbox).
- Update grading using AI.

## User stories
1. As a student, I want to take a full simulated Bac paper with a timer, so that I’m used to exam conditions.
2. As a student, I want to see my progress per chapter, so that I know where my gaps are.
3. As a student, I want to solve a practice test and see my score right away, so that I know where I stand.
4. As a parent, I want a weekly email with my child’s progress, so that I can step in early.
5. As a student, I want to browse a subject’s chapters and past papers, so that I can choose what to practise.

## Tech stack
.NET 10, ASP.NET Core, EF Core, SQL Server, Docker, Azure

## How to run
 to be filled in later.