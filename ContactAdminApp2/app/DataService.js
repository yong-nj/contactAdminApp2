contactAdminApp2.factory('DataService',
     ["$http",
       function ($http) {
                     
           var getContacts = function () {
               return $http.get("Contact/GetContacts");
           };

           //  searchContacts is never used
           var searchContacts = function (searchText) {
               return $http.get("Contact/SearchContacts/" + searchText);
           };
           // end searchContacts is never used

           var getContact = function (id) {
                 
               return $http.get("Contact/GetContacts/" + id);
           };

        
       var insertContact = function (newContact) {
            return $http.post("Contact/Create", newContact);
        };

        var updateContact = function (contact) {
            return $http.post("Contact/Update", contact);
        };

        var deleteContact = function (id) {
            return $http.post("Contact/Delete", { id: id });

         

        };

       return {
           insertContact: insertContact,
           updateContact: updateContact,
           deleteContact: deleteContact,
           getContact: getContact,
           getContacts: getContacts,
           searchContacts:searchContacts
       };

    }]);