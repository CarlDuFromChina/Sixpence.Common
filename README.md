# Sixpence.Common

> 一个基于 .Net6.0 的通用工具框架

## 介绍

`Sixpence.Common`基于 .Net6.0，提供了丰富的工具了和扩展类，集成了开发常用的`IoC`、`Logging`和`Config`模块。使用本项目，我相信会帮助你大大提升开发效率

## 特性

+ 14个工具类
+ 8个扩展类
+ `log4net`日志集成
+ `IoC`静态类实现
+ 基于`json`的配置类封装
+ 全局上下文

## 示例

### 日志

日志默认输出：all.txt、error.txt

all：调试日志

error：错误日志

1、简单使用

```csharp
LogUtil.Debug("系统启动");
LogUtil.DebugAsync("系统启动"); // 异步
LogUtil.Error("系统错误", new Exception("数据库连接异常"));
```

2、自定义

```csharp
var logger = LoggerFactory.GetLogger("myjob");
logger.Debug("任务开始执行！");
```

### 依赖注入

1、添加服务

```csharp
// startup.cs
services.AddServiceContainer();
```

2、标记注入

```csharp
// 1、打标记
[ServiceRegister]
public interface ITest
{
    string GetTypeName();
}

public class ATest : ITest
{
    public string GetTypeName()
    {
        return this.GetType().Name;
    }
}
```

3、获取注入

```csharp
ServiceContainer.Resolve<ITest>(); // 获取第一个注入对象
ServiceContainer.ResolveAll<ITest>(); // 获取所有注入对象
ServiceContainer.Resolve<ITest>("BTest"); // 根据类名获取注入对象
ServiceContainer.Resolve<ITest>(name => name == "ATest"); // 自定义筛选获取注入第一个对象
ServiceContainer.ResolveAll<ITest>(name => name.Contains("Test")); // 自定义筛选获取对象
```

### 扩展函数

**String**

```csharp
Contains(this string source, string toCheck, StringComparison comp); // 判断字符串是否存在于一个字符串中
ToLogString(this Dictionary<string, object> paramList); // 转换Dictionary参数为日志文本格式
string GetSubString(this string value, string str); // 获取查找到的字符串之后的字符串
string GetFileType(this string value); // 根据文件后缀名获取文件类型
string Replace(this string value, Dictionary<string, string> keyValuePairs); // 替换匹配字符串
Stream ToStream(this string value);
```

**DataRow**

```csharp
Dictionary<string, object> ToDictionary(this DataRow row);
Dictionary<string, object> ToDictionary(this DataRow dataRow, DataColumnCollection columnCollection);
```

**DataTable**

```csharp
bool IsEmpty(this DataTable dt); // 判断表是否为空
```

**Enum**

```csharp
GetEnumName<T>(this int status); // 根据枚举的值获取枚举名称
string GetDescription(this Enum value, Boolean nameInstead = true); // 获取枚举值的描述
T GetValue<T>(this Enum value); // 获取枚举值
T GetEnum<T>(this string value); // 根据描述找到枚举
```

**IEnumerable**

```csharp
bool IsEmpty<T>(this IEnumerable<T> ts);
DataTable ToDataTable<T>(this IList<T> data);
DataTable ToDataTable<T>(this IList<T> data, DataColumnCollection columns);
void Each<T>(this IEnumerable<T> src, Action<T> callback);
List<T> ToList<T>(this T[] array);
List<Type> GetTypes(this List<Assembly> assemblies);
```

**Long**

```csharp
ToDateTimeString(this long value, string format = "yyyy-MM-dd HH:mm");
DateTime ToDateTime(this long value);
```

**Object**

```csharp
Dictionary<string, object> ToDictionary(this object param);
```

**Stream**

```csharp
Encrypt<Algorithm>(Stream stream, byte[] key) where Algorithm : SymmetricAlgorithm;
Stream Decrypt<Algorithm>(Stream stream, byte[] key) where Algorithm : SymmetricAlgorithm;
byte[] ToByteArray(this Stream stream);
string ToString(this Stream stream);
```

## 关于

本项目是作者利用空余时间开发，使用过程中遇到问题，欢迎报告`issue`

