module app.services {
    'use strict';

    export interface IBaseDataService<entity> {
        rootUrl: string;
        get(id: string): ng.IPromise<IEnvelope<entity>>;
        getAll(page: number, limit: number): ng.IPromise<IPagedResultEnvelope<entity[]>>;
        update(item: entity): ng.IPromise<IEnvelope<entity>>;
        delete(id: string): ng.IPromise<IEnvelope<entity>>;
        deleteAll(): ng.IPromise<IEnvelope<entity>>;
    }

    export interface IEnvelope<entity> {
        Message: string;
        Success: boolean;
        Content: entity;
    }

    export interface IPagingInfo {
        Page: number;
        Limit: number;
        PageCount: number;
        TotalCount: number;
    }

    export interface IPagedResultEnvelope<entity> {
        Message: string;
        Success: boolean;
        Content: entity;
        Paging: IPagingInfo;
    }

    export class BaseDataService<entity> implements IBaseDataService<entity> {

        static $inject = ['$http'];

        constructor(private $http: ng.IHttpService) {

        }

        rootUrl: string;

        get(id: string): ng.IPromise<IEnvelope<entity>> {
            return this.$http.get(this.rootUrl + '/get?id=' + id)
                .then((response: ng.IHttpPromiseCallbackArg<IEnvelope<entity>>): IEnvelope<entity> => {
                    return <IEnvelope<entity>>response.data;
                });
        }

        getAll(page: number = 0, limit: number = 25): ng.IPromise<IPagedResultEnvelope<entity[]>> {
            return this.$http.get(this.rootUrl + '/get?page=' + page.toString() + '&limit=' + limit.toString())
                .then((response: ng.IHttpPromiseCallbackArg<IPagedResultEnvelope<entity[]>>): IPagedResultEnvelope<entity[]> => {
                    return <IPagedResultEnvelope<entity[]>>response.data;
                });
        };

        update(item: entity): ng.IPromise<IEnvelope<entity>> {
            return this.$http.post(this.rootUrl + '/post',item)
                .then((response: ng.IHttpPromiseCallbackArg<IEnvelope<entity>>): IEnvelope<entity> => {
                    return <IEnvelope<entity>>response.data;
                });
        };

        delete(id: string): ng.IPromise<IEnvelope<entity>> {
            return this.$http.delete(this.rootUrl + '/delete?id=' + id)
                .then((response: ng.IHttpPromiseCallbackArg<IEnvelope<entity>>): IEnvelope<entity> => {
                    return <IEnvelope<entity>>response.data;
                });
        };

        deleteAll(): ng.IPromise<IEnvelope<entity>> {
            return this.$http.delete(this.rootUrl + '/deleteall')
                .then((response: ng.IHttpPromiseCallbackArg<IEnvelope<entity>>): IEnvelope<entity> => {
                    return <IEnvelope<entity>>response.data;
                });
        };
    }

}