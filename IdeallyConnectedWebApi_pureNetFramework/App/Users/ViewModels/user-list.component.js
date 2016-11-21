/*
    user-list.component.js

    This component creates a template and controller that displays users.
    Remember, just drop <user-list></user-list> into HTML to use! Components help clean up
    HTML and create a safe and isolated environment from other JS code. What happens in the component,
    stays in the component. Also, the suffix "component" in the file name is for user clarity.

    Why use components? If, for example, a user list needs to appear on different pages, then it would be
    convenient to make a component that will display it instead of reimplementing it. Refactoring would
    also be easier. 

    reference: https://docs.angularjs.org/tutorial/step_03
*/
angular.
    module("user").
    component("userList", {
        template: "<ul>" + 
            '<li ng-repeat="user in $ctrl.users">' + 
                "<span>{{ user.name }}</span>" +
                "<p>{{ phone.snippet }}</p>" +
            "</li>" + 
          "</ul>" +
          "<p>Total number of users: {{ $ctrl.users.length }}</p>" 
          ,
        controller: function UserListController() {
            this.users = [
                {
                    name: "Kevin Perez",
                    snippet: "Yo yo what's everyone?"
                }, {
                    name: "Steven Jackson",
                    snippet: "What up people?"
                }, {
                    name: "John Johnathan",
                    snippet: "Hey hey heyyy!"
                }
            ];
        }
});