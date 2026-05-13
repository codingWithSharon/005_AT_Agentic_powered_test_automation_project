# READ ME PLEASE

This guide will help you set up your first automated test project with agentic AI. For this project we will keep the testtargets simple so we can focus on learning more about agentic AI. For this project we will use CLaude Code.

## Getting started

For this project you need the following:

- VS Code
- Claude account
- Claude subscription
    You can get the subscription through the webpage but you can only pay by entering your credit card details. If you want to use Apple pay or Google pay then you need to create a Claude account using either your Apple or Google account and download the Claud app and upgrade the subscription from there.

### Steps

Step 1 Create a folder and called it whatever you want
Step 2 Open the folder in VS Code
Step 3 Go to the extensions tab and search for "claude" and install "Claude Code for VS Code"
Step 4 Login into Claude account within VS Code
            This will direct you to the the login page where you enter the email you have used for Claude. An email with a code will be sent. NOTE: I f you have used your Apple account than it is likely Apple has used a relay mailingaddress, in that case you do NOT enter your direct email but instead enter the relay mail. Otherwise you will not recieve the email.
Step 5 Create a .md file and call it "CLAUDE.md"
            This file will run everytime you use Claude. You can think of this file as your runsettings file. Because you do not want to be repeating yourself. In this file you can give context, who you are, set out rules and give it resources.
Step 6 Install tools
            Claude cannot install extensions for you so you need to do that yourself. For this project make sure the following extension are installed:

            - Playwright Test for VSCode
            - 


Step 7 Create workflows
            You can create permanent workflows that can bereused. You also save these files as .md files. When creating NEW workflows make sure the chat is in PLANMODE. You can set it in planmode by pressing SHIFT + TAB 2x and to go back press SHIFT + TAB 1x.

            In this project we started out with this first prompt:

            <!--# Workflow: Playwright Test Generation

            ## Goal
            Automate the discovery and creation of C# Playwright tests using POM and ISTQB standards.

            ## Instructions for Claude
            1. **Analyze Requirements:** Reference the @ISTQB Syllabus to identify testing types (Functional, Boundary, etc.).
            2. **Discovery:** Use the Playwright MCP to navigate to the **[TARGET_URLS]** provided by the user.
            3. **Map Locators:** Identify the best `getByRole` or `getByTestId` locators as per @CLAUDE.md.
            4. **Draft POM:** Create a plan for Page Objects following the @Project Template structure.
            5. **Execution:** After approval in /plan mode, generate the C# files and a GitHub Action YML.

            workflows/create_playwright_tests.md -->
