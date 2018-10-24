Voronoi Diagram ([DEMO](https://krisonepiece.000webhostapp.com/Voronoi/))
===
![](https://i.imgur.com/Zif8FT9.png)

# 簡介
實作 Voronoi Diagram 演算法，可用滑鼠在畫布上點選座標，亦可透過文字檔輸入座標點，以 Divide and Conquer 來處理四個點以上的運算，最後用 Step by Step 的方式來輸出結果。

# 軟體規格書
## 輸出與輸入（資料）規格
### 輸入
1. 滑鼠在畫布上任意點擊，畫布大小為 603*603
2. 輸入x軸及y軸座標
3. 隨機產生數個點
4. 讀入「輸入文字檔」，[《詳細格式》](https://drive.google.com/open?id=1ijeRMVzabdqh7_Z0HxL4DEMnZ_KB8BXM)
5. 讀入「輸出文字檔」，直接在畫布繪出圖形
### 輸出
1. 按下Save，輸出「輸出文字檔」
2. 輸出文字檔格式如下：  
   輸入的座標點：P x y   // 每個點佔一行，兩整數 x, y 為座標。  
   線段：E x1 y1 x2 y2   // (x1, y1) 為起點，(x2, y2) 為終點，其中 x1≦x2 或 x1=x2, y1≦y2  
   座標點排列在前半段，線段排列在後半段。  
   座標點以 lexical order順序排列（即先排序第一維座標，若相同，則再排序第二維座標；線段亦以lexical order順序排列。  
3. 輸出文字檔案範例：
   P 100 100  
   P 100 200  
   P 200 100  
   P 200 200  
   E 0 150 150 150  
   E 150 0 150 150  
   E 150 150 150 600  
   E 150 150 600 150  

## 功能規格與介面規格
### 主介面
![](https://i.imgur.com/aplgQWU.jpg)

### 功能
<img src="https://i.imgur.com/YoAJ1F5.png" height="30" width="30">(Clear)：清除畫布  
<img src="https://i.imgur.com/vCowcPc.png" height="30" width="30">(Open)：開啟檔案  
<img src="https://i.imgur.com/5gZ4tjP.png" height="30" width="30">(Save)：輸出檔案  
<img src="https://i.imgur.com/93PCCgv.png" height="30" width="30">(Next)：讀取下一筆資料  
<img src="https://i.imgur.com/l206ZWp.png" height="30" width="30">(Run)：執行  
<img src="https://i.imgur.com/IA7vCNR.png" height="30" width="30">(Step)：Step By Step  
<img src="https://i.imgur.com/9JV1H63.png" height="30" width="30">(Add)：加入指定座標點  
<img src="https://i.imgur.com/8544Cmk.png" height="30" width="30">(Random)：產生隨機點  
<img src="https://i.imgur.com/UaI9kWe.png" height="30" width="30">(About)：關於  

### 軟體測試規劃書
以「隨機+共線」的情況，來測試以下幾種點個數的範圍：  
* 1～3 點：三點以下直接解
* 4～6 點：三點以上會 Divide 及 Merge 一次
* 7～12 點：七點以上會 Divide 及 Merge 多次
* 大於 12 點：多點測試

# 軟體說明
## 安裝說明
1. 下載[主程式](https://drive.google.com/open?id=1QTxoaVpjRJgu8uRFe7wKyHA5L54COcl8)後，執行「VoronoiDiagram.exe」即可。  
<img src="https://i.imgur.com/oMOMex6.jpg" height="80" width="70">  

## 使用說明
### 繪製點座標
於畫布區繪製點座標，有以下幾種方法：  
* 點擊滑鼠左鍵於畫布區域  
* 開啟測資檔案  
* 於上方工具列輸入x軸及y軸座標，並點選「Add」按鈕  
* 於上方工具列輸入欲產生隨機點的個數，並點選「Random」按鈕  
![](https://i.imgur.com/axwH1zz.jpg)

### 繪製 Voronoi Diagram
* 按下「Run」按鈕，繪製最終結果  
* 按下「Step」按鈕，一步一步繪製結果  
![](https://i.imgur.com/vDr3kjU.jpg)
![](https://i.imgur.com/e3vPL6T.jpg)

### 輸出結果
* 按下「Save」將結果輸出至文字檔  
![](https://i.imgur.com/IfMDoYc.jpg)

# 程式設計
## 資料結構
我是使用C#原本就有的PointF型態來儲存點座標，自己額外再建了以下三種結構：  
1. Edge：儲存線段的結構
```C#=
PointF A;   // 線端點A座標
PointF B;   // 線端點B座標
PointF a;   // 做中垂線的點a座標
PointF b;   // 做中垂線的點b座標
```
2. Voronoi：儲存Voronoi Diagram的結構
```C#=
List<PointF> pList;   // 座標點集合
List<Edge> hpList;    // Hyper Plane 集合
List<Edge> vList;     // Voronoi 集合
```
3. Record：儲存紀錄的結構，用於Step By Step功能
```C#=
List<PointF> pList;   // 點集合
List<Edge> eList;     // 線段集合
int type;             // 類型
bool clear;           // 是否需要清除之前的步驟
bool enable;          // 是否顯示
```
