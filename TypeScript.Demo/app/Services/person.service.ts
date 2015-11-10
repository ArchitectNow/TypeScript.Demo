module app.services {
    'use strict';


    export class PersonService extends BaseDataService<TypeScript.Demo.Data.Models.Person> {

        constructor($http: ng.IHttpService) {

            super($http);

            this.rootUrl = '/api/person'; 

            

        }


        searchPeople(searchString: string): ng.IPromise<TypeScript.Demo.Data.Models.Person[]> {
            return null;
        }
    }

    angular
        .module('app.services')
        .service('app.services.PersonService', PersonService);
}