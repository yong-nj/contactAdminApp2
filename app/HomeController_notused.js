contactAdminApp2.controller("HomeController",
    ["$scope", "$state", "$filter", "DataService",
    function ($scope, $state, $filter, DataService) {

        //  $scope.contacts = DataService.getContacts();

        DataService.getContacts().then(
           function (results) {
               // on success
               $scope.contacts = results.data;
               //$scope.contact = $filter('filter')(results.data, {id : 2});
               //$scope.editableContact = angular.copy($scope.contact);

           },
           function (results) {
               // on error
               $scope.contacts = results.data;
           }
       );

      
        $scope.addContactForm = function () {
          //  $location.path('/newContactForm');
            $state.go('newContactForm');
        };

        $scope.editContactForm = function (id) {
            //  $location.path('/updateContactForm/' + id);
            $state.go('updateContactForm', { id: id });
        };

        

    }]);