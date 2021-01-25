# Trabalho Final de Aprendizado Não Supervisionado 

Trabalho de aprendizado não supervisionado para a turma II da Pós em Data Science, com o professor Márcio Koch.

## Tecnologia

O trabalho foi feito em C# /.Net Core 3.1

Como não sou dev no dia a dia, é quase certo que o repositório GIT tem coisas a mais que não precisariam ser commitadas. E que existem parte do código que podem ser melhoradas.

Além disso, usei o emguCV (via NuGet) como wrapper do OpenCV. Até a metada da segunda aula, tentei adaptar o código Java para C#.

O grande problema que enfrentei foi que não encontrei no emguCV o equivale ao mat.put, o que inviablizou a minha implementação em C#. 

Até tentei pedir ajuda via [Stack Overflow](https://stackoverflow.com/questions/65864907/emgucv-equivalent-to-java-mat-puti-0-mv), mas não obtive resposta de como fazer alguma coisas. Com isso, acabei desistindo e deixei apenas para assistir as aulas novamente e fazer o trabalho final.

~~Então o código será simplificado e, onde possível, farei apenas chamadas em alto nível para o Open/Emgu CV.~~

~~Mas, como se pode ver, eu tentei fazer/enteder as rotinas.~~

Em cima da hora consegui ajuda para adaptar o código em C# e fazer funcionar. Com isso acabei fazendo tudo em C#. Só o desempenho não ficou legal, imagino que seja por conta dos unboxing que tenho que fazer em alguns momentos. 

Mas está feito, uma cópia básica do que foi em Java, e está funcionando. 

Se houvesse tempo hábil, tentaria fazer em Python, mas sou menos familiar com Python ainda.

## Como rodar

Usar o Visual Studio, a versão Community é Free e nós como alunos / professores da FURB temos direito a uma licença do Visual Studio Professional.

O código usa a biblioteca emguCV, via NuGet. O Visual Studio deve baixar todas as bibliotecas e permitir a execução. Mas, de novo, não sou dev no dia a dia, então é possível que não fucione de primeira. É possível que até mesmo via VS Code funcione. 

Os caminhos dos arquivos estão setados relativamentes, então não deve haver dificuldades com relação a diretórios.

## Execução

Testando com 10 componentes
K: 10, Acerto: 56,10
minDis 1483,22, maxDis: 2640,46, minRec: 1533,93, maxRec: 2066,90:
*********************************************************************
Testando com 11 componentes
K: 11, Acerto: 60,16
minDis 1597,74, maxDis: 2646,41, minRec: 1525,73, maxRec: 2043,06:
*********************************************************************
Testando com 12 componentes
K: 12, Acerto: 70,73
minDis 1761,17, maxDis: 2653,11, minRec: 1482,12, maxRec: 1984,86:
*********************************************************************
Testando com 13 componentes
K: 13, Acerto: 78,86
minDis 1991,03, maxDis: 3308,70, minRec: 1463,19, maxRec: 1978,56:
*********************************************************************
Testando com 14 componentes
K: 14, Acerto: 83,74
minDis 2225,54, maxDis: 3388,95, minRec: 1462,50, maxRec: 1877,34:
*********************************************************************
Testando com 15 componentes
K: 15, Acerto: 87,80
minDis 2358,27, maxDis: 3040,85, minRec: 1425,63, maxRec: 1857,67:
*********************************************************************
Testando com 16 componentes
K: 16, Acerto: 91,87
minDis 2480,05, maxDis: 3058,56, minRec: 1423,30, maxRec: 1853,65:
*********************************************************************
Testando com 17 componentes
K: 17, Acerto: 91,87
minDis 2639,12, maxDis: 3328,21, minRec: 1392,09, maxRec: 2009,99:
*********************************************************************
Testando com 18 componentes
K: 18, Acerto: 92,68
minDis 2664,59, maxDis: 3468,15, minRec: 1346,81, maxRec: 2007,25:
*********************************************************************
Testando com 19 componentes
K: 19, Acerto: 93,50
minDis 2732,64, maxDis: 3518,77, minRec: 1278,01, maxRec: 1937,55:
*********************************************************************
Testando com 20 componentes
K: 20, Acerto: 92,68
minDis 2832,83, maxDis: 3527,95, minRec: 1274,87, maxRec: 1929,67:
*********************************************************************
