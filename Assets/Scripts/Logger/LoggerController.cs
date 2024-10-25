using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoggerController : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI logTextPrefab;  // TextPrefabに割り当てるTextMeshProコンポーネント

  [SerializeField]
  private int maxLogLines = 10;  // 表示するログの最大行数（tailで出力する行数）

  private Queue<string> logMessages = new Queue<string>();  // ログメッセージを保存するためのキュー

  private void OnEnable()
  {
    // ログメッセージをキャッチするイベントに登録
    Application.logMessageReceived += HandleLog;
  }

  private void OnDisable()
  {
    // イベント登録解除
    Application.logMessageReceived -= HandleLog;
  }

  // ログメッセージを処理するメソッド
  private void HandleLog(string logString, string stackTrace, LogType type)
  {
    // ログメッセージをキューに追加
    logMessages.Enqueue(logString);

    // キューの数が最大行数を超えたら古いメッセージを削除
    if (logMessages.Count > maxLogLines)
    {
      logMessages.Dequeue();
    }

    // TextPrefabに表示するテキストを更新
    logTextPrefab.text = string.Join("\n", logMessages.ToArray());
  }

  void Update()
  {
  }
}
