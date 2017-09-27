contactAdminApp2.controller('cfController',
    ["$scope",  "$window", "$routeParams", "DataService",
    function cfController($scope,  $window, $routeParams, DataService) {

        $scope.editableContact = {};

        if ($routeParams.id) {
            $scope.contact = DataService.getContact($routeParams.id).then(
               function (results) {
                   // on success
                   $scope.contact = results.data[0];                 
                   $scope.editableContact = angular.copy($scope.contact);
               },
               function (results) {
                   // on error
                   $scope.contacts = results.data;
               });
        }
        else {
            $scope.contact = { id: -1 };
        };

            
        $scope.cancelForm = function () {
            $window.history.back();
        }

        $scope.submitForm = function () {
            $scope.$broadcast('show-errors-event');
            if ($scope.cfContactForm.$invalid) return;

            //today date
            var today = new Date();
            var dd = today.getDate();
            var mm = ("0" + (today.getMonth() + 1)).slice(-2); //January is 0!
            var yyyy = today.getFullYear();
            //end today date
            if ($scope.editableContact.birthDate == undefined) $scope.editableContact.birthDate = yyyy + '-' + mm + '-' + dd;

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
                var r = confirm("Are you sure you want to update this contact?  click Ok to update this contact, Click cancel to cancel.");
                if (r == true) {
                    DataService.updateContact($scope.editableContact);
                    $window.location.href = "/";
                } else {
                    // txt = "You pressed Cancel!";
                }
                
            }

        };

        //calendar

    }]);