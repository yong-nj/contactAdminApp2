
var contactAdminApp2 = angular.module('contactAdminApp2', ["ngRoute", "ui.bootstrap"]);

contactAdminApp2.config(["$routeProvider", "$locationProvider",
    function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/home", {
                templateUrl: "app/Home.html",
                controller: "HomeController"
            })
            .when("/newContactForm", {
                templateUrl: "app/ContactForm/cfContact.html",
                controller: "cfController"
            })
            .when("/updateContactForm/:id", {
                templateUrl: "app/ContactForm/cfContact.html",
                controller: "cfController"
            })
            .otherwise({
                redirectTo: "/home"
            });
      
        //// $locationprovider.html5Mode(false);

        ////$locationProvider.html5Mode({
        ////    enabled: true,
        ////    requireBase: false
        ////});

    }]);


