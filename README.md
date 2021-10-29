# CPU Process Scheduling Simulation
vb
working

<img src="./res/"><br></br>
AAA

<br>

## < For What & How it works >

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

- 선점형
- 비선점형
- 스케쥴링
- 프로세스 상태 및 상태전이

-도착시간
-실행시간
-대기시간
-반환시간

-우선순위
-CPU 유휴시간
-평균대기,실행,반환시간

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