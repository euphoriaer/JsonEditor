

# JsonEditor
Json文件综合编辑器，内嵌数据库，支持上万Json文件的增删改查，根据数据库支持Json之间的跳转

## 使用
打开视图-Json生成器，然后拖入Excel，根据Excel生成Json文件，同时加入数据库
![在这里插入图片描述](https://img-blog.csdnimg.cn/88ac1ba8ab5b4020b1cc4ee0ea31be69.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2V1cGhvcmlhcw==,size_16,color_FFFFFF,t_70)

## 1.Json查看器，查看Json文件
文件目录上方支持模糊搜索
文件支持多选添加文件，文件夹
左键目录多选，右键快速删除文件
支持文本与Form同步修改
![在这里插入图片描述](https://img-blog.csdnimg.cn/6949a85483d24441881b1eda9a202ace.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2V1cGhvcmlhcw==,size_16,color_FFFFFF,t_70)


## 2.内嵌数据库索引，通过Excel生成的Json项目，可以进行右键跳转
比如我有一个Json是人物，里面有个技能，然后右键可以直接跳转到该技能的Json信息

![在这里插入图片描述](https://img-blog.csdnimg.cn/564c0165b4a048ceacfa94a37af69302.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2V1cGhvcmlhcw==,size_16,color_FFFFFF,t_70)



# JsonEditorTree
Json生成器，是对JsonEditor的补充，虽然JsonEditor也具有生成Json功能，但是不能生成多重嵌套的单个Json（只能生成最多两重嵌套），而JsonEditorTree可以根据Json数据的嵌套关系生成单个或者多个Json文件


JsonEditorTree是JsonEditor的分支版本，后续会合并到JsonEditor中，如果需要更复杂强大的Json生成选择JsonEditorTree，如果更关注Json数据之间的关系与查看编辑，则JsonEditor更加合适，源码在JsonEditor的分支版本
![在这里插入图片描述](https://img-blog.csdnimg.cn/c4de28e4ab1d4f1f9f405f2d147e95ae.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2V1cGhvcmlhcw==,size_16,color_FFFFFF,t_70)

## 使用
打开后，默认一个Game节点，这是根节点，根据此节点，可以创建树型从属结构的json数据。
![在这里插入图片描述](https://img-blog.csdnimg.cn/be5297c2adf04d3dacb769cb3e549771.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2V1cGhvcmlhcw==,size_16,color_FFFFFF,t_70)

## 生成嵌套Json文件
将数据之间的归属关系建立好，左侧是关系，右侧是该节点数据
注意：只有前两行数据可以保存为Json的键值对关系，多余行请建立新的节点，或者采用JsonEditor，按行生成所有Json数据。
![在这里插入图片描述](https://img-blog.csdnimg.cn/bae3945a7c7649a3b85e3cbeb72814b2.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2V1cGhvcmlhcw==,size_16,color_FFFFFF,t_70)
右键想要生成数据的根节点，然后生成即可
![在这里插入图片描述](https://img-blog.csdnimg.cn/e31e16ddbd5a4717a18c6f8d1da6cd2c.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2V1cGhvcmlhcw==,size_16,color_FFFFFF,t_70)
以Game为例，将所有Json文件生成单个文件，如下图
![在这里插入图片描述](https://img-blog.csdnimg.cn/716163b27ce446c1b29a04be0cb11d90.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2V1cGhvcmlhcw==,size_16,color_FFFFFF,t_70)


如果觉得不错的话，Star一下吧(^  .  ^)
> 下载地址:win10 
>  [https://github.com/euphoriaer/JsonEditor/releases](https://github.com/euphoriaer/JsonEditor/releases)

