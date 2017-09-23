
    <script>
        var demoFunction = function(){
            var website = "google.com";
            return "Output from Factory is : " + website
        }
   


    var firstApp = angular.module('firstApp', []);


    firstApp.factory('FactoryDemo', demoFunction);

    firstApp.controller 
    ('ControllerName',  function ($scope, FactoryDemo){
    $scope.FactoryResult ="this is from factory: " + FactoryDemo ;
    }
    );

    firstApp.service('ServiceDemo', demoFunction);

    firstApp.controller
    ('ControllerName',  function ($scope, ServiceDemo){
    $scope.FactoryResult ="this is from Service: " + FactoryDemo ;
    }
    );

 </script>



