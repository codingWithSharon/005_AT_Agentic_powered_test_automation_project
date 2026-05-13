# Test Plan Summary

## Overview

| Item | Detail |
|------|--------|
| Framework | C# / NUnit / Playwright 1.59 |
| Browser | Chromium (headless) |
| Target | https://the-internet.herokuapp.com |
| Total Tests | 12 |
| ISTQB Types | Functional, Boundary Value, State Transition |

---

## Page Coverage

| Page | URL | POM File | Test Fixture |
|------|-----|----------|--------------|
| Add/Remove Elements | /add_remove_elements/ | AddRemoveElementsPage.cs | AddRemoveElementsTests.cs |
| Checkboxes | /checkboxes | CheckboxesPage.cs | CheckboxesTests.cs |
| Floating Menu | /floating_menu | FloatingMenuPage.cs | FloatingMenuTests.cs |

---

## Locator Strategy

No `data-testid` attributes exist on these pages. All locators use `getByRole` for robustness:

| Element | Locator |
|---------|---------|
| Add Element button | `GetByRole(AriaRole.Button, new() { Name = "Add Element" })` |
| Delete button(s) | `GetByRole(AriaRole.Button, new() { Name = "Delete" })` |
| Checkboxes | `GetByRole(AriaRole.Checkbox).Nth(index)` |
| Nav links | `GetByRole(AriaRole.Link, new() { Name = "..." })` |

---

## Test Count by Fixture

| Fixture | Tests | ISTQB Types |
|---------|-------|-------------|
| AddRemoveElementsTests | 4 | Functional, Boundary Value |
| CheckboxesTests | 4 | Functional, State Transition |
| FloatingMenuTests | 4 | Functional |
| **Total** | **12** | |

---

## ISTQB Test Type Mapping

| Test | ISTQB Type | Rationale |
|------|-----------|-----------|
| AddOneElement_ShouldShowDeleteButton | Functional | Verifies core feature behaviour |
| AddMultipleElements_ShouldShowCorrectCount | Boundary Value | Upper boundary for add action |
| RemoveElement_ShouldDecreaseCount | Functional | Verifies state change on delete |
| RemoveAllElements_ShouldShowNoneRemaining | Boundary Value | Lower boundary — zero elements |
| Checkbox1_DefaultState_ShouldBeUnchecked | Functional | Initial state verification |
| Checkbox2_DefaultState_ShouldBeChecked | Functional | Initial state verification |
| ToggleCheckbox1_ShouldBecomeChecked | State Transition | Unchecked → Checked |
| ToggleCheckbox2_ShouldBecomeUnchecked | State Transition | Checked → Unchecked |
| FloatingMenu_ShouldBeVisible_OnPageLoad | Functional | Verifies menu renders correctly |
| FloatingMenu_ShouldRemainVisible_AfterScroll | Functional | Verifies sticky/fixed positioning |
| FloatingMenu_HomeLink_ShouldBeClickable | Functional | Verifies link is interactive |
| FloatingMenu_AllLinks_ShouldBeVisible | Functional | Verifies all four links present |

---

## CI/CD

- **Trigger:** push/PR to main + daily schedule (00:00 UTC)
- **Workflow file:** `.github/workflows/playwright-tests.yml`
- **Artifact:** TRX test results uploaded on every run
