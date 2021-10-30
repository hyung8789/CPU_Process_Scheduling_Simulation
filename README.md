# CPU Process Scheduling Simulation
vb
working

<img src="./res/"><br></br>
AAA

<br>

## < For What & How it works >

<b>- 프로세스 스케쥴링</b>

    여러 프로세스가 번갈아 사용하는 CPU의 자원을 어떤 시점에 어떤 프로세스에 할당할지 결정하는 것

<b>- 스케쥴링의 목적</b>

     1) 자원 할당의 공정성 보장 : 어떤 프로세스도 실행을 무한 연기해서는 안된다.
     2) 단위시간당 처리량 최대화 : CPU의 처리량을 최대화하여 가능한 많은 프로세스에 서비스를 제공한다.
     3) 적절한 반환시간 보장 : 적절한 시간안에 프로세스가 작업을 마칠 수 있도록 해야 한다.
     4) 예측 가능성 보장 : 프로세스를 시스템 부하와 상관없이 거의 같은 시간에 거의 같은 비용으로 실행할 수 있어야 한다.
     5) 오버헤드 최소화 : 자원 낭비를 막기 위해 오버헤드를 최소화해야한다.
     6) 자원 사용의 균형 유지 : 시스템의 자원을 쉬지 않고 사용할 수 있도록 스케쥴링을 해야 한다. 따라서 유휴 상태의 자원을 사용하려는 프로세스에 특별한 혜택을 줄 수도 있다.
     7) 반환시간과 자원의 활용 간에 균형 유지 : 충분한 자원을 활용할 경우 반환시간을 빠르게 할 수 있지만, 한 프로세스가 너무 많은 자원을 차지하면 시스템의 자원 활용도가 떨어진다.
     8) 실행 대기 방지 : 프로세스의 실행을 무한 연기하지 않도록 높은 우선순위를 부여하거나 Aging 방법을 이용한다.
     9) 우선순위 : 프로세스에 우선순위를 부여하여 높은 우선순위를 가진 프로세스에 먼저 자원을 할당하거나, 선점할 수 있도록 한다.
     10) 서비스 사용 기회 확대 : 프로세스에 더 자주 서비스 사용 기회를 주어야 한다.
     11) 서비스 수 감소 방지 : 시스템에 부하가 많이 걸릴 때 갑자기 서비스 수가 감소하면 안 된다.

<b>- 선점형 스케쥴링</b>

<b>- 비선점형 스케쥴링</b>

<b>- 프로세스 상태 및 상태전이</b>

       1) 준비상태 (READY) : CPU의 자원을 할당받으려고 기다리는 상태
       2) 실행상태 (RUNNING) : 프로세스가 실행을 위해 선택 된 상태, CPU(또는 코어) 당 최대 하나의 실행 중인 프로세스가 있으며 프로세스의 명령은 CPU(또는 코어)중 하나에 의해 실행된다.
       3) 종료상태 (TERMINATED) : 프로세스가 자신의 작업을 모두 완료한 상태

       ※ 실제 프로세스의 상태에는 추가적으로 I/O 작업과 같은 처리를 위한 중지(BLOCKED) 상태가 존재하며, 실행 상태에서 I/O 작업 발생 시 중단 상태로 전이되지만, 이는 단순화하기 위해 생략하며, 
       CPU에 의해 프로세스간 선점을 위한 문맥교환이 발생할 경우 강제로 실행 상태에서 준비 상태로 전이한다.



- 프로세스 도착시간
- 프로세스 실행시간
- 프로세스 대기시간
- 프로세스 반환시간
- Time Quantum (Time Slice)
- 프로세스 우선순위
- CPU 유휴시간
- 평균 실행시간, 평균 대기시간, 평균 반환시간


<b>- 준비 큐 (Ready Queue)</b>

    CPU를 할당받아 실행하려고 기다리는 프로세스들이 대기하는 큐

<b>- 도착 큐 (Arrival Queue)</b>

    프로세스 준비 큐에 삽입되어 준비 상태로 들어가기 전 프로세스 간 도착시간에 따른 빠른 순으로 준비 큐에 동적으로 추가를 위한 큐로서 도착 큐는 모든 프로세스가 동일시간에 도착한다고 가정 시 사용하지 않는다.
    실제 CPU의 스케쥴링 동작과정에 도착 큐라는 개념이 존재하지 않지만, 각 프로세스 별 도착시간을 할당하여 시뮬레이션하는 상황을 사용자가 각 프로세스의 도착시간에 따라 도착시간에 해당하는 프로세스를 
    실행한다고 가정하여 실행 된 프로세스가 CPU로부터 자원을 할당받기 위해 프로세스 준비 큐로 들어가는 상황을 만들기 위해 도착 큐를 별도로 사용하였다.

<br>

## < Features >
- Supported Scheduling Type

      1) First Come First Service (비선점형) : 선입선출
      2) Shortest Job First (비선점형) : 실행시간이 제일 짧은 순으로 처리
      3) Highest Response-Ratio Next (비선점형) : (대기시간+실행시간) / 실행시간으로 우선순위 할당하여 높은 순으로 처리
      4) Priority-based scheduling (비선점형) : 초기 할당 된 우선순위를 이용하여 우선순위 기반 스케쥴링
      5) Shortest Remaining Time Next (선점형) : 미리 정의 된 TimeQuantum 만큼 실행 후 남은 실행시간이 제일 짧은 순으로 우선순위 부여하여 처리, SJF의 선점형
      6) Round-Robin (선점형) : 미리 정의 된 TimeQuantum 만큼 돌아가며 처리
      7) Priority-based scheduling (선점형) : 초기 할당 된 우선순위를 이용하여 우선순위 기반 스케쥴링

- 출력 결과

      1) 스케쥴링 과정에 따른 각 프로세스의 상태전이 및 수행과정
      2) 총 시뮬레이션 소요시간
      3) 누적 CPU 유휴시간
      4) 누적 실행시간
      5) 누적 대기시간
      6) 누적 반환시간
      7) 누적 문맥교환 횟수
      8) 평균 실행시간
      9) 평균 대기시간
      10) 평균 반환시간



<br>

## < Demo & Screenshot >


<br>

## < System Requirement >
- .Net Framework 4.8

<br>

## < References >
- 그림으로 배우는 구조와 원리 : 운영체제 개정 3판 (한빛 아카데미)
- 2021 시나공 정보처리기사 필기 & 실기
- http://www.soen.kr/book/dotnet/annex/annex4.htm
- https://en.wikipedia.org/wiki/Process_state
- https://docs.oracle.com/cd/E19683-01/816-5042/psched-16/index.html
- https://examradar.com/process-scheduling-algorithm-fcfs-first-come-first-serve-questions-answers/
- https://www.studytonight.com/operating-system/highest-response-ratio-next-hrrn-scheduling
- MSDN .net Example

<br>

## < License >
[This application is licensed under the MIT License.](./LICENSE)</b><br><br>