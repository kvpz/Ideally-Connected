Type of App: ASP.NET Web Application (.NET Framework) - Single Page App template with MVC and Web API hosted on Azure and using Individual User Accounts


### AngularJS
https://www.youtube.com/watch?v=f67PFtrldGQ (AngularJS for ASP.NET MVC Developers)
When you click on an href link in a page, Angular can intersect that. But if the URL is written manually in the URL bar, 
then it will query the server (Angular has no control over that).

Since ng-app can only be applied once... use ng-non-bindable to manually add more (see 51:45 in video).

#### Difference between ng-app and data-ng-app 
There is absolutely no difference between the two except that certain HTML5 validators will throw an error on a property like ng-app, but they 
don't throw an error for anything prefixed with data-, like data-ng-app.
So to answer your question, use data-ng-app if you would like validating your HTML to be a bit easier.

#### ng-view
This allows multiple views on a single page. It creates a place holder where a corresponding view ( html or ng-template view) can be placed based on the configuration.

#### ng-template directive
Used to create an html view using script tag. It contains "id" attribute which is used by $routeProvider to map a view with a controller.

#### Services
They can be created with factory and service. In built services are prefixed with $.
**$http** is used to make ajax calls to get the server data.
**$route** is used to define the routing info and so on.
