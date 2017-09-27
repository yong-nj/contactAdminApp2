contactAdminApp2.controller("HomeController",
    ["$scope", "$location","$routeParams", "DataService",
    function ($scope, $location, $routeParams, DataService) {

        var searchVal = $scope.searchText;
    
            DataService.getContacts().then(
               function (results) {
                   $scope.contacts = results.data;
                   $scope.contacts_copy = angular.copy($scope.contacts);

                   paginationSetting();
               },
               function (results) {
                   $scope.contacts = results.data;
               }
           );
      
       

        $scope.search = function () {           
            if ($scope.searchText != '') {
                $scope.contacts = filter($scope.searchText);             
            }
            else {
                $scope.contacts = $scope.contacts_copy;
            }
            paginationSetting();
        };

        //pagination setting
        function paginationSetting() {
            
            $scope.totalItems = $scope.contacts.length;
            $scope.currentPage = 1;

            $scope.setPage = function (pageNo) {
                $scope.currentPage = pageNo;
            };

            $scope.pageChanged = function () {
                $log.log('Page changed to: ' + $scope.currentPage);
            };

            $scope.maxSize = 5;
            $scope.bigTotalItems = 175;
            $scope.bigCurrentPage = 1;
        }

        //filter the record by first Name
        function filter(fName) {
            var result = [];
            for (var i = 0, len = $scope.contacts.length; i < len; i++) {               
                if ($scope.contacts[i].firstName.toLowerCase().indexOf(fName) != -1)             
                    result.push($scope.contacts[i]);               
            }

            return result;
        }

        $scope.addContactForm = function () {
            $location.path('/newContactForm');
        };
       
        $scope.editContactForm = function (id) {
            $routeParams.id = id;
            $location.path('/updateContactForm/' + id);
        };

        $scope.deleteContact = function (id) {
            var r = confirm("Are you sure you want to delete this contact?  click Ok to delete this contact, Click cancel to cancel.");
            if (r == true) {
                DataService.deleteContact(id);
                location.reload();
            } else {
               // txt = "You pressed Cancel!";
            }
               
        };

    }]);