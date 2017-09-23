contactAdminApp2.controller('cfController',
    ["$scope", "$location", "$window", "result",
    function cfController($scope, $location, $window,result) {
     
       
        //if ($routeParams.id) {
        //     $scope.contact = DataService.getContact($routeParams.id);           
        //}         
        //else {
        //    $scope.contact = { id: 0 };
        //}
          
        $scope.contact = result;
        $scope.editableContact = angular.copy($scope.contact);

        $scope.cancelForm = function () {          
            $window.history.back();
        }

        $scope.submitForm = function () {
            $scope.$broadcast('show-errors-event');
          //  if ($scope.contactForm.$invalid)
         //       return;

            if ($scope.editableContact.id == undefined) {
                DataService.insertContact($scope.editableContact).then(
                    function (results) {
                        // on success
                        $scope.contact = angular.copy($scope.editableContact);
                        $window.history.back();
                    },
                    function (results) {
                        // on error
                        $scope.hasFormError = true;
                        $scope.formErrors = results.statusText;
                    });
                
            }
            else {
                DataService.updateContact($scope.editableContact);
            }
            $scope.contact = angular.copy($scope.editableContact);
            $window.history.back();
        }

    }]);