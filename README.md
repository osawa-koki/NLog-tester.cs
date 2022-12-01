# NLog-tester.cs

NLogの学習用プロジェクト。  

## 説明

### ライブラリのインストール

Nugetパッケージマネージャから「NLog」を検索、インストール。

### 設定ファイルの作成

プログラムディレクトリに「NLog.config」ファイルを作成。  
中身は以下の通り。  

```NLog.config
<?xml version="1.0" encoding="utf-8" ?>
<nlog
	xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    autoReload="true"
    throwExceptions="true"
    internalLogLevel="Off" internalLogFile="../logs/nlog_internal.log">

	<targets>
		<!-- ファイル -->
		<target
			name="logFile"
            xsi:type="File"
            encoding="UTF-8"
            writeBom="true"
            lineEnding="Default"
            layout="${longdate} ${level:uppercase=true:padding=-5} [${threadid}] ${logger} - ${message} ${exception:format=tostring}"
            fileName="../logs/${processname}_${date:format=yyyyMMdd}.log"
            archiveFileName="../logs/backup/${processname}_{###}.log"
            archiveEvery="Day"
            archiveNumbering="Sequence"
            maxArchiveFiles="10" />

		<!-- Console -->
		<target name="console" xsi:type="ColoredConsole" layout="${longdate} ${level:uppercase=true:padding=-5} ${message} ${exception:format=tostring}" />

	</targets>
	<rules>
		<logger name="*" minlevel="Trace" writeTo="logFile" />
		<logger name="*" minlevel="Trace" writeTo="console" />
	</rules>
</nlog>
```

出力ディレクトリにコピーするかどうかの設定で、「常にコピー」を選択する。  

### ロガーインスタンスの生成

```cs
static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
```

通常は共有するため、静的メンバとして宣言。  

### ログの出力

```cs
logger.Trace("Trace ログです。");
logger.Debug("Debug ログです。");
logger.Info("Info ログです。");
logger.Warn("Warn ログです。");
logger.Error("Error ログです。");
logger.Fatal("Fatal ログです。");
```

## 参考文献

- <https://sabakunotabito.hatenablog.com/entry/2021/10/25/005740>
