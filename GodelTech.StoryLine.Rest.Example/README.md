# GodelTech.StoryLine.Rest.Example

## Overview

**GodelTech.StoryLine.Rest.Example** is example of using **GodelTech.StoryLine.Rest** and **GodelTech.StoryLine.Utils** packages.

Example consists of two parts: REST API and unit-test application. REST API is an application that provides `GET`, `POST`, `PUT`, `DELETE` methods with fake implementation for test purposes. Subsystem tests project contains integration tests related to REST API.

## Actions

In order to reuse testing logic in multiple places custom caction can be created. You can find example if `Actions` folder. To create Action you need to create `ActionBuilder` that inherited from class `IActionBuilder` and class inherited from `IAction`. `IActionBuilder` and `IAction` are a part of `GodelTech.StoryLine.Contracts` package. After that you can use this action in your tests by executing the following code:

```csharp
.HasPerformed<ActionBuilder>() 
```

or

```csharp
.Performs<ActionBuilder>()
```

## Resources

Resources folder contains all tests grouped by tested REST API resource. If you need to run any action before tested action use `HasPerformed` method. If you need action context after action execution you can create `Actor` and send it into `ActionBuilder`, after that while `Performs` method execution you can map context and use data in test:

```csharp
 var actor = new Actor();

    Scenario.New()
        .Given(actor)
        .HasPerformed<CreateUser>()
        .When(actor)
        .Performs<HttpRequest, UserDocument>((res, doc) => res
            .Method("DELETE")
            .Url($"v1/users/{doc.Id}"))
```

If you test is consist of only one Action you can use `Performs` method

```csharp
    Scenario.New()
        .When()
        .Performs<CreateUser>()
        .Run();
```