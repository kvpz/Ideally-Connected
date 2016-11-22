/*
    user-list.component.js

    This component creates a template and controller that displays users.
    Remember, just drop <user-list></user-list> into HTML to use! Components help clean up
    HTML and create a safe and isolated environment from other JS code. What happens in the component,
    stays in the component. Also, the suffix "component" in the file name is for user clarity.

    Why use components? If, for example, a user list needs to appear on different pages, then it would be
    convenient to make a component that will display it instead of reimplementing it. Refactoring would
    also be easier. 

    Using external templates can incure costly HTTP requests and data usage. To avoid this while maintaining
    external template, view the documentation for $templateRequest and $templateCache.

    reference: https://docs.angularjs.org/tutorial/step_03
*/
/*
template: "<ul>" + 
    '<li ng-repeat="user in $ctrl.users">' + 
        "<span>{{ user.name }}</span>" +
        "<p>{{ phone.snippet }}</p>" +
    "</li>" + 
  "</ul>" +
  "<p>Total number of users: {{ $ctrl.users.length }}</p>" 
  ,
*/
/*
angular.
    module("user").
    component("userList", {
        templateUrl: 'App/Users/Views/user-list.template.html',
        controller: function UserListController() {
            this.users = [
                {
                    name: "Kevin Perez",
                    snippet: "Yo yo what's everyone?",
                    age: 23
                }, {
                    name: "Steven Jackson",
                    snippet: "What up people?",
                    age: 40
                }, {
                    name: "John Johnathan",
                    snippet: "Hey hey heyyy!",
                    age: 10
                }
            ];
            // note that this will select "newest" from the drop down as the first display format. MVVM
            //this.orderProp = "age";
        }
    });
*/

// The URL in http.get() is relative to the main view file.
// The $http.get method returns a "promise object"
// then() is used to handle the asynchronous response and assign the phone data to the controller (as the property 'users')
//    also, then() is a callback function.
angular.
    module("user").
    component("userList", {
        templateUrl: "App/Users/Views/user-list.template.html",
        controller: ["$http",
            function UserListController($http) {
                var self = this; // this allows the controller instance, this, to be accessible in .then().
                self.orderProp = "age";
            
                $http.get("App/Users/users.json").then(function (response) {
                    self.users = response.data.slice(0,3); // Angular detected the JSON response and parsed it into the "data" property of response
                    // slice() limits the number of JSON objects to output
                });
            }
        ]
    });