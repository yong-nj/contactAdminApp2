contactAdminApp2.factory('DataService',
     ["$http",
       function ($http) {
                     
           var getContacts = function () {
               return $http.get("Contact/GetContacts");
           };

           var getContact = function (id) {
               //return $http.get("Contact/GetContacts/" + id).then(function (result) {                   
               //    return result.data;
               //});       
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

          //  $http.post("@Url.Action("Delete", "MyController")", { id : id } , function (data) {} );

        };

       return {
           insertContact: insertContact,
           updateContact: updateContact,
           deleteContact: deleteContact,
           getContact: getContact,
           getContacts: getContacts
       };

    }]);