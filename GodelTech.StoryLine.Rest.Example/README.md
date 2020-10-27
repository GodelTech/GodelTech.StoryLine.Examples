# GodelTech.StoryLine.Rest.Example

## Overview

**GodelTech.StoryLine.Rest.Example** is example of using **GodelTech.StoryLine.Rest** and **GodelTech.StoryLine.Utils** packages.

Example consists of 2 parts: REST API and unit-test application. REST API is an application that has `GET`, `POST`, `PUT`, `DELETE` methods with mock realization for testing. Unit-test application shows all tests based on REST API application.

## Actions

If you have a part that needs to be in different unit tests you can create Actions. To create Action you need to create ActionBuilder that inherited from class **IActionBuilder** and class inherited from **IAction**. IActionBuilder and IAction are a part of **GodelTech.StoryLine.Contracts** package. After that you can use this action in your tests by executing 

```c#
.HasPerformed<ActionBuilder>() 
```
or
```c# 
.Performs<ActionBuilder>()
```

## Resources

Resources folder contains all unit tests that application have. If you need to run any action before test use **HasPerformed** method. If you need action context after action execution you can create Actor and send it into ActionBuilder, after that while **Performs** method execution you can map context and use data in test:

```c#
 var actor = new Actor();

    Scenario.New()
        .Given(actor)
        .HasPerformed<CreateUser>()
        .When(actor)
        .Performs<HttpRequest, UserDocument>((res, doc) => res
            .Method("DELETE")
            .Url($"v1/users/{doc.Id}"))
```

If you test is consist of only one Action you can use **Performs** method

```c#
    Scenario.New()
        .When()
        .Performs<CreateUser>()
        .Run();
```