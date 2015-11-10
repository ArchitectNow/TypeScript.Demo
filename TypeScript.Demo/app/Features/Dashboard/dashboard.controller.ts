module app.features {
    'use strict';

    interface IDashBoardScope {
        personService: app.services.PersonService,
        loadPeople: () => void;
        people: TypeScript.Demo.Data.Models.Person[];
        selectedPerson: TypeScript.Demo.Data.Models.Person;
        pagingInfo: app.services.IPagingInfo;
        isLoading: boolean;
        selectPerson(person: TypeScript.Demo.Data.Models.Person): void;
    }

    class DashboardController implements IDashBoardScope {

        personService: app.services.PersonService;
        people: TypeScript.Demo.Data.Models.Person[];
        selectedPerson: TypeScript.Demo.Data.Models.Person;
        pagingInfo: app.services.IPagingInfo;
        isLoading: boolean;

        static $inject = [
            '$scope',
            'app.services.PersonService'
        ];

        constructor($scope: ng.IScope,
            personService: app.services.PersonService) {
            this.personService = personService;
            this.isLoading = false;


            var _new = new TypeScript.Demo.Data.Models.Person();

            _new.NameFirst = "Kevin";

            
        }

        selectPerson(person: TypeScript.Demo.Data.Models.Person) {
            this.selectedPerson = person;

        };

        loadPeople(): void {
            var _result = this.personService.getAll(0,10);
            
            this.isLoading = true;

            _result.then((result) => {
                if (result.Success) {
                    this.people = result.Content;
                    this.pagingInfo = result.Paging;
                }
                else {
                    alert(result.Message);
                }
            }).catch(reason => {
                alert(reason);
            }).finally(() => {
                this.isLoading = false;
            });
        }
    }

    angular
        .module('app.features')
        .controller('app.features.DashboardController',
        DashboardController);
}