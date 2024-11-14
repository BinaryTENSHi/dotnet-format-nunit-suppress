# dotnet format 'error CS8618: Non-nullable field' weirdness

This repository contains a minimal reproducible example for a weirdness in `dotnet format`

## Description

The `Example.Test` project uses `NUnit` for unit testing. `NUnit` provides a suppressor that suppresses `CS8618`
when a non-nullable field is initialized via a `SetUp` or `OneTimeSetUp` method. See:
[`NUnit3002`](https://docs.nunit.org/articles/nunit-analyzers/NUnit3002.html).

## Error / Weirdness

Building and testing the solution works perfectly fine as expected.

```shell
[HOST dotnet-format-nunit-suppress] dotnet build
Restore complete (0.3s)
  Example succeeded (0.1s) → Example/bin/Debug/net9.0/Example.dll
  Example.Test succeeded (0.0s) → Example.Test/bin/Debug/net9.0/Example.Test.dll

Build succeeded in 0.7s
[HOST dotnet-format-nunit-suppress] dotnet test
Restore complete (0.4s)

Build succeeded in 0.5s
```

Running `dotnet format --verify-no-changes` seems to not include the `NUnit3002` suppressor and fails with a `CS8618`
error:

```shell
[HOST dotnet-format-nunit-suppress] dotnet format --verify-no-changes
/home/{username}/work/dotnet-format-nunit-suppress/Example.Test/CalculatorTests.cs(7,24): error CS8618: Non-nullable field '_calculator' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable. [/home/ch1010926/work/dotnet-format-nunit-suppress/Example.Test/Example.Test.csproj]
```

## Workaround

Setting the `EnforceCodeStyleInBuild` in `Directory.Build.props` to `false` or commenting it out makes `dotnet format`
work as expected.

```shell
[HOST dotnet-format-nunit-suppress] dotnet format --verify-no-changes && echo ok
ok
```
