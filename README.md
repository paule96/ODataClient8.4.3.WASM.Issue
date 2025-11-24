# ODataWebApplication2

This project has an OData API and an Blazor WASM frontend.

The Blazor WASM frontend can be started in two versions:

- Configuration Debug
  - uses OData Client 8.4.2
- Configuration Broken
  - uses OData Client 8.4.3

You can start the projects in each version.
In the Broken version, the OData Client 8.4.3 produces an error when trying to query the OData API:

```
Microsoft.AspNetCore.Components.WebAssembly.Rendering.WebAssemblyRenderer[100]
      Unhandled exception rendering component: An error occurred while processing this request.
Microsoft.OData.Client.DataServiceQueryException: An error occurred while processing this request.
 ---> System.InvalidOperationException: An error occurred while processing this request.
 ---> System.PlatformNotSupportedException: Cannot wait on monitors on this runtime.
   at System.Threading.Monitor.ObjWait(Int32 millisecondsTimeout, Object obj)
   at System.Threading.Monitor.Wait(Object obj, Int32 millisecondsTimeout)
   at System.Threading.ManualResetEventSlim.Wait(Int32 millisecondsTimeout, CancellationToken cancellationToken)
   at System.Threading.Tasks.Task.SpinThenBlockingWait(Int32 millisecondsTimeout, CancellationToken cancellationToken)
   at System.Threading.Tasks.Task.InternalWaitCore(Int32 millisecondsTimeout, CancellationToken cancellationToken)
   at System.Threading.Tasks.Task.InternalWait(Int32 millisecondsTimeout, CancellationToken cancellationToken)
   at System.Threading.Tasks.Task.Wait(Int32 millisecondsTimeout, CancellationToken cancellationToken)
   at System.Threading.Tasks.Task.Wait()
   at Microsoft.OData.Client.HttpClientRequestMessage.<>c__DisplayClass44_0.<ConvertHttpWebResponse>b__2()
   at Microsoft.OData.Client.HttpWebResponseMessage.GetStream()
   at Microsoft.OData.Client.QueryResult.AsyncEndGetResponse(IAsyncResult asyncResult)
   --- End of inner exception stack trace ---
   at Microsoft.OData.Client.BaseAsyncResult.EndExecute[QueryResult](Object source, String method, IAsyncResult asyncResult)
   at Microsoft.OData.Client.QueryResult.EndExecuteQuery[Customer](Object source, String method, IAsyncResult asyncResult)
   --- End of inner exception stack trace ---
   at Microsoft.OData.Client.QueryResult.EndExecuteQuery[Customer](Object source, String method, IAsyncResult asyncResult)
   at Microsoft.OData.Client.DataServiceRequest.EndExecute[Customer](Object source, DataServiceContext context, String method, IAsyncResult asyncResult)
   at Microsoft.OData.Client.DataServiceQuery`1[[NS.Customer, BlazorApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]].EndExecute(IAsyncResult asyncResult)
   at System.Threading.Tasks.TaskFactory`1[[System.Collections.Generic.IEnumerable`1[[NS.Customer, BlazorApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]].FromAsyncCoreLogic(IAsyncResult iar, Func`2 endFunction, Action`1 endAction, Task`1 promise, Boolean requiresSynchronization)
--- End of stack trace from previous location ---
   at BlazorApp1.Pages.Home.OnInitializedAsync() in D:\labs\ODataWebApplication2\BlazorApp1\Pages\Home.razor:line 28
   at Microsoft.AspNetCore.Components.ComponentBase.RunInitAndSetParametersAsync()
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.GetErrorHandledTask(Task taskToHandle, ComponentState owningComponentState)
```