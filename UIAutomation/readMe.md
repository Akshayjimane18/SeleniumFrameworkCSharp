Packages/plugin
1. Selenium Webdriver
2. Nunit
3. Nunit 3 Adapter
4. DotnetSeleniumExtras.waithelper
5. Selenium helper
6. Seleniu wait helper
7. Webdrivermanager
8. .net sdk
9. pageobjects
10. pageobjects core
11. ExtentReports


To run Test in terminal through tags then use below command in terminal

Category("Regression")

dotnet test UIAutomation.csproj --filter TestCategory=Smoke -- TestRunParameters.Parameter(name="browserName",value="Chrome")
