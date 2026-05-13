# Test Plan Summary

## Overview

| Item | Detail |
|------|--------|
| Language | JavaScript |
| Framework | @playwright/test 1.60+ |
| Browser | Chromium |
| Target | https://the-internet.herokuapp.com |
| Total Tests | 12 |
| ISTQB Types | Functional, Boundary Value, State Transition |

---

## Page Coverage

| Page | URL | POM File | Test Fixture |
|------|-----|----------|--------------|
| Add/Remove Elements | /add_remove_elements/ | AddRemoveElementsPage.js | AddRemoveElementsTests.spec.js |
| Checkboxes | /checkboxes | CheckboxesPage.js | CheckboxesTests.spec.js |
| Floating Menu | /floating_menu | FloatingMenuPage.js | FloatingMenuTests.spec.js |

---

## Locator Strategy

No `data-testid` attributes exist on these pages. All locators use `getByRole` for robustness:

| Element | Locator |
|---------|---------|
| Add Element button | `getByRole('button', { name: 'Add Element' })` |
| Delete button(s) | `getByRole('button', { name: 'Delete' }).nth(index)` |
| Checkboxes | `getByRole('checkbox').nth(index)` |
| Nav links | `getByRole('link', { name: '...' })` |

---

## Test Count by Fixture

| Fixture | Tests | ISTQB Types |
|---------|-------|-------------|
| AddRemoveElementsTests.spec.js | 4 | Functional, Boundary Value |
| CheckboxesTests.spec.js | 4 | Functional, State Transition |
| FloatingMenuTests.spec.js | 4 | Functional |
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

## Headless / Headed Mode

| Environment | Mode | How |
|-------------|------|-----|
| Local (default) | Headless | `npx playwright test` |
| Local (headed) | Headed | `HEADED=1 npx playwright test` |
| CI (GitHub Actions) | Headless | `CI=true` is auto-set; `HEADED` is unset |

Single `playwright.config.js` handles both — no separate runsettings files needed.

---

## CI/CD

- **Trigger:** push/PR to main + daily schedule (00:00 UTC)
- **Workflow file:** `.github/workflows/playwright-tests.yml`
- **Artifact:** HTML report uploaded on every run (`playwright-report/`)
