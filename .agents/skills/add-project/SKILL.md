---
name: add-project
description: Add a new GitHub repository project to the portfolio website. Fetches repository details, generates 3 candidate branding images in distinct art styles, stores them in wwwroot/images/, updates projects.json, and builds the solution.
---

# Add Project Skill

Use this skill whenever the user requests to add a new GitHub project (e.g., from `https://github.com/armckinney/<repo-name>`) to the portfolio.

## Workflow

### 1. Fetch Repository Details
Fetch and read the repository details and README to understand the project purpose, key features, and technology stack:
```
https://raw.githubusercontent.com/armckinney/<repo-name>/main/README.md
```
*(If `main` branch 404s, try `master` branch).*

Extract:
- **Title**: Project Name
- **Domain**: Domain / Category (e.g., DevOps, AI & Systems, Automation, Infrastructure)
- **Description**: Concise single-sentence summary of the repository value proposition
- **Technologies**: List of core languages, frameworks, or tools used
- **Highlights**: 3 key bullet points summarizing core capabilities

---

### 2. Generate 3 Candidate Branding Images

Using the prompt format from below, select **3 different art styles** from the allowed list:
- `3D`
- `digital painting`
- `vector art`
- `flat design`
- `pixel art`
- `hand-drawn`
- `watercolor`
- `oil painting`

#### Image Prompt Template
```text
can you also do a branding image for this repo?
https://github.com/armckinney/<repo-name>

DO NOT INCLUDE ANY WORDS.

Use the following art style:
- <selected_art_style>

use themes you find on this web page in the image design:
https://raw.githubusercontent.com/armckinney/<repo-name>/refs/heads/main/README.md
```

#### Image Generation & Storage Instructions
1. For each of the 3 chosen art styles, call `generate_image` with a detailed prompt incorporating:
   - The selected art style
   - Core visual themes extracted from the project README
   - Strict instruction: **DO NOT INCLUDE ANY WORDS OR TEXT**.
2. Save/copy the 3 generated images directly into `Portfolio/wwwroot/images/`:
   - `Portfolio/wwwroot/images/<repo-name>-1.png`
   - `Portfolio/wwwroot/images/<repo-name>-2.png`
   - `Portfolio/wwwroot/images/<repo-name>-3.png`
3. Also set candidate #1 as the active default image by copying it to:
   - `Portfolio/wwwroot/images/<repo-name>.png`
4. Present all 3 options in an interactive carousel artifact so the user can easily select their preferred design.

---

### 3. Update `Portfolio/wwwroot/data/projects.json`

Append the new project entry into `Portfolio/wwwroot/data/projects.json`:

```json
{
    "id": "<next_sequential_id>",
    "title": "<Project Title>",
    "domain": "<Domain>",
    "description": "<Concise description>",
    "technologies": [
        "<Tech 1>",
        "<Tech 2>",
        "<Tech 3>"
    ],
    "highlights": [
        "<Highlight 1>",
        "<Highlight 2>",
        "<Highlight 3>"
    ],
    "codeUrl": "https://github.com/armckinney/<repo-name>",
    "image": "images/<repo-name>.png",
    "pin": true
}
```

*Note: Position the project in the `projects` array according to user preference or at the desired pinned position.*

---

### 4. Build & Verify

Execute build validation using `run_command`:
```bash
dotnet build Portfolio/Portfolio.csproj
```

Ensure `0 Warning(s), 0 Error(s)` before declaring completion.
