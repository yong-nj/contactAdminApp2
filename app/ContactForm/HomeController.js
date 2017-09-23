contactAdminApp2.controller("HomeController",
    ["$scope", "$location","$routeParams", "DataService",
    function ($scope, $location, $routeParams, DataService) {
       
        DataService.getContacts().then(
           function (results) {
               $scope.contacts = results.data;
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
           },
           function (results) {
               $scope.contacts = results.data;
           }
       );


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