/// <reference path="include.ts" />

module TypeScript.Demo.Data.Models {
	interface ILogMessage  {
		LogDate: any;
		Message: string;
	}

	export class LogMessage implements ILogMessage  {
		LogDate: any;
		Message: string;
	}

	interface IPerson  {
		NameFirst: string;
		DateOfBirth: any;
		ChrisName: string;
	}

	export class Person implements IPerson  {
		NameFirst: string;
		DateOfBirth: any;
		ChrisName: string;
	}

	interface IUser  {
		Email: string;
		IsActive: boolean;
	}

	export class User implements IUser  {
		Email: string;
		IsActive: boolean;
	}

}
