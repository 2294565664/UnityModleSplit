using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DotweenTest : MonoBehaviour
{
    public Transform Target;
    public Camera camera;
    public Material material;
    public Gradient gradient;
    public Text text;

    private Tween _tweener;

    private Vector3 LocalPosition;
    private Vector3 LocalRotation;
    private Quaternion TargetQuaternion = new Quaternion(0.1f, 0.1f, 0.1f, 0.1f);
    private Vector3 TargetPosition = new Vector3(1, 1, 1);
    private Vector3 TargetRotation = new Vector3(0, 90, 0);

    private TweenCallback CallBack;
    private TweenCallback PreCallBack;
    private TweenCallback InsertCallBack;

    // Start is called before the first frame update
    void Start()
    {
        LocalPosition =Target.position;
        LocalRotation = Target.rotation.eulerAngles;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 50), "Move"))
        {
            //Move();

            StartCoroutine(Wait());
        }
    }

    private void Move()
    {
        #region Position
        //�ı���������
        //�ƶ���������һ��������Ҫ�ƶ�����Ŀ��㣬�����ƶ���������ľ���
        //Target.DOMove(new Vector3(1, 1, 1), 2);

        //ֻ����x���ϵ��ƶ���������������ͬ��
        //Target.DOMoveX(1, 2);
        #endregion

        #region Rotation
        //������ת
        //��ת��������ֵ���ı����ŷ����
        //Target.DORotate(new Vector3(0, 90, 0), 2);

        //��ת��������ֵ���ı������Ԫ��
        //Target.DORotateQuaternion(new Quaternion(0.1f, 0.1f, 0.1f, 0.1f), 2);

        //�ֲ���ת
        //��ת��������ֵ���ı����ŷ����
        //Target.DOLocalRotate(new Vector3(0, 90, 0), 2);

        //��ת��������ֵ���ı������Ԫ��
        //Target.DOLocalRotateQuaternion(new Quaternion(0.1f, 0.1f, 0.1f, 0.1f), 2);

        //�ڸ���ʱ���ڣ�ƽ�����������z��������ָ��Ŀ���
        //Target.DOLookAt(new Vector3(0, 1, 0), 2);
        #endregion

        #region Scale
        //�ı���������ŵ�Ŀ��ֵ
        //Target.DOScale(new Vector3(2, 2, 2), 2);
        //������������ͬ��
        //Target.DOScaleX(3, 2);
        #endregion

        #region Punch
        //��һ������ punch����ʾ����ǿ��
        //�ڶ������� duration����ʾ��������ʱ��
        //���������� vibrato���𶯴���
        //���ĸ����� elascity: ���ֵ��0��1��
        //                    ��Ϊ0ʱ����������ʼ�㵽Ŀ���֮���˶�
        //                    ��Ϊ0ʱ������㸳��ֵ����һ����������Ϊ���˶����򷴷���ĵ㣬������������Ŀ���֮���˶�
        //Target.DOPunchPosition(new Vector3(0, 1, 0), 2, 2, 0.1f);
        //Target.DOPunchRotation(new Vector3(0, 90, 0), 2, 2, 0.1f);
        //Target.DOPunchScale(new Vector3(2, 2, 2), 2, 2, 0.1f);
        #endregion

        #region Shake
        //����������ʱ�䣬�������𶯣�����ԣ�����
        //����ʱ�䣺����ʱ��
        //������ʵ�ʾ����𶯵ķ���,�����������ʩ�ӵ����Ĵ�С ʹ��Vector3����ѡ��ÿ������ͬ��ǿ��
        //�𶯣��𶯴���
        //����ԣ��ı��𶯷�������ֵ����С��0~180��
        //�����������˶�����Ƿ����ƶ��ص�ԭ��λ��
        //Target.DOShakePosition(1, 5, 10, 50, true);
        //Target.DOShakeRotation(3);
        //Target.DOShakeScale(3);
        #endregion

        #region Blend
        //��Blend���Ƶķ����������϶���
        //ԭ��ͬʱִ������Move������ֻ��ִ�����µ�һ����������
        //Target.DOMove(Vector3.one, 2);
        //Target.DOMove(Vector3.one * 2, 2);
        //����������˶����ˣ�2,2,2��������

        //DOBlendableMoveBy�����������ص�
        //������ͬʱִ��
        //Target.DOBlendableMoveBy(new Vector3(1, 1, 1), 1);
        //Target.DOBlendableMoveBy(new Vector3(-1, 0, 0), 1);
        //������ʵ��Ϊ��0,0,0������󶯻�ֹͣʱ��������ǣ�0,1,1��
        //������������
        //transform.DOBlendableMoveBy(new Vector3(1, 1, 1), 1);
        //������ʵ��Ϊ��1,1,1������󶯻�ֹͣʱ��������ǣ�2,2,2��
        //���Ĳ�������Ŀ��㣬����Ҫ�ƶ�����

        //������������ͬ��
        //transform.DOBlendableRotateBy()
        //transform.DOBlendableScaleBy()
        //transform.DOBlendablePunchRotation()
        #endregion

        #region Camera
        //1��������Ļ�ӽǵĿ�߱� ��һ�������ǿ�ߵı�ֵ
        //camera.DOAspect(0.6f, 2);

        //2���ı����background��������ɫ
        //camera.DOColor(Color.blue, 2);

        //3���ı�����������ֵ
        //camera.DONearClipPlane(200, 2);

        //4���ı����Զ�����ֵ
        //camera.DOFarClipPlane(2000, 2);

        //5���ı����FOV��ֵ
        //camera.DOFieldOfView(30, 2);

        //6���ı����������С
        //camera.DOOrthoSize(10, 2);

        //7��������Ļ���ؼ������ʾ��Χ
        //camera.DOPixelRect(new Rect(0f, 0f, 600f, 500f), 2);

        //8��������Ļ�ٷֱȼ������ʾ��Χ
        //camera.DORect(new Rect(0.5f, 0.5f, 0.5f, 0.5f), 2);

        //9�������
        //  �����Ч�� ����������ʱ�䣬�������𶯣�����ԣ�����
        //  ������ʵ�ʾ����𶯵ķ���,�����������ʩ�ӵ����Ĵ�С ʹ��Vector3����ѡ��ÿ������ͬ��ǿ��
        //�𶯣��𶯴���
        //����ԣ��ı��𶯷�������ֵ����С��0~180��
        //�����������˶�����Ƿ����ƶ��ص�ԭ��λ��
        //camera.DOShakePosition(1, 10, 10, 50, false);
        #endregion

        #region Material
        //material.DOColor(Color.black, 2);

        //2������shader�����������޸���ɫ
        //material.DOColor(Color.clear, "_Color", 2);

        //3���޸�alphaֵ
        //material.DOFade(0, 2);

        //4����ɫ����
        //  Gradient��unity�Ľ���༭���������н���༭����ͼ��
        //material.DOGradientColor(gradient, "_Color", 3);

        //5���ı����offset��ֵ
        //material.DOOffset(new Vector2(1, 1), 2);

        //6���ı��ṩ��shader���Ե����ƶ�Ӧ��Vector4ֵ
        //material.DOVector(new Vector4(0, 0, 0, 1), "_Color", 3);

        //7����ɫ���
        //  ��λ�û�϶���ͬ������ͬʱִ�ж������ţ����������һ�����ɫ
        //material.DOBlendableColor(Color.red, "_Color", 3);
        #endregion

        #region Text
        //�ѵ�һ��������������ݰ���ʱ�䣬һ����һ���ֵ����뵽�ı�����
        //text.DOText("context", 2);
        #endregion
    }

    #region Sequence
    private void MoveSequence()
    {
        //Sequence quence = DOTween.Sequence();

        //1����Ӷ�����������
        //  quence.Append(Target.DOMove(Vector3.one, 2));

        //2�����ʱ����
        //  quence.AppendInterval(1);

        //3����ʱ�����붯��
        //  ��һ������Ϊʱ�䣬�˷����Ѷ������뵽�涨��ʱ���
        //  ����仰Ϊ��������DORotate������ӵ��˶��е�0��ʱִ�У���Ȼ������������ӽ����е�
        //  quence.Insert(0, Target.DORotate(new Vector3(0, 90, 0), 1));

        //4�����뵱ǰ����
        //  Join�������ö����뵱ǰ����ִ�еĶ���һ��ִ��
        //  �������д��룬DOMove���DOScaleһ��ִ��
        //  quence.Append(Target.DOScale(new Vector3(2, 2, 2), 2));
        //quence.Join(Target.DOMove(Vector3.zero, 2));

        //5��Ԥ��Ӷ���
        //  Ԥ��� ��ֱ����Ӷ�����Append��ǰ�棬Ҳ�����ʼ��ʱ��
        //  quence.Prepend(Target.DOScale(Vector3.one * 0.5f, 1));
        //������Ҫ�ر�˵һ��Ԥ��ӵ�ִ��˳������
        //������Ҳ��ȡ�˶��е����ʣ�������Ԥ�����ԭ���ĵĶ��������һ���������
        //���磺
        //  Sequence quence = DOTween.Sequence();
        //quence.Append(Target.DOMove(Vector3.one, 2));
        //quence.Prepend(Target.DOMove(-Vector3.one * 2, 2));
        //quence.PrependInterval(1);
        //ִ��˳���� PrependInterval----Prepend---- - Append
        //   ���������ӵĻ��ڶ��е����

        //6��Ԥ���ʱ����
        //quence.PrependInterval(1);

        //�ص�����

        // 1��Ԥ��ӻص�
        //  quence.PrependCallback(PreCallBack);

        //2���ڹ涨��ʱ������ص�
        //  quence.InsertCallback(0, InsertCallBack);

        //3����ӻص�
        //  quence.AppendCallback(CallBack);
       
    }
    #endregion

    #region Tweener������
    private void TweenerSetting()
    {
        TweenParams para = new TweenParams();

        //1�����ö���ѭ��
        //  ��һ��������ѭ������ - 1��������ѭ��
        //  �ڶ���������ѭ����ʽ
        //   Restart ���¿�ʼ
        //   Yoyo ����ʼ���˶���Ŀ��㣬�ٴ�Ŀ����˶�����������ѭ��
        //   Incremental   һֱ�����˶������˶�
        //    para.SetLoops(-1, LoopType.Yoyo);

        //2�����ò���
        //Target.DOMove(Vector3.one, 2).SetAs(para);

        //3)�����Զ�ɱ������
        //    Target.DOMove(Vector3.one, 1).SetAutoKill(true);

        //4)from����
        //  ����;
        //    Target.DOMove(Vector3.one, 2).From(true);
        //From���� isRelative(��Ե�)��
        //     Ϊtrue������ľ���ƫ����������ǰ���� + ����ֵ = Ŀ��ֵ
        //     Ϊfalese������ľ���Ŀ��ֵ��������ֵ = Ŀ��ֵ


        //5)���ö�����ʱ
        //    Target.DOMove(Vector3.one, 2).SetDelay(1);

        //6�����ö����˶����ٶ�Ϊ��׼
        //   ���磺
        //    Target.DOMove(Vector3.one, 1).SetSpeedBased();
        //ʹ��SetSpeedBasedʱ���ƶ���ʽ�ͱ�����ٶ�Ϊ��׼
        //ԭ����ʾ����ʱ��ĵڶ����������ͱ�ɱ�ʾ�ٶȵĲ�����ÿ���ƶ��ĵ�λ��


        //7�����ö���ID
        //    Target.DOMove(Vector3.one, 2).SetId("Id");

        //8�������Ƿ�ɻ���
        //  Ϊtrue�Ļ�������������ᱻ���գ�������������Ȼ�����ֱ������
        //    Target.DOMove(Vector3.one, 2).SetRecyclable(true);

        //9�����ö���Ϊ�����˶�
        //    ���磺
        //    Target.DOMove(Vector3.one, 2).SetRelative(true);
        //SetRelative���� isRelative(��Ե�)��
        //      Ϊtrue������ľ���ƫ����������ǰ���� + ����ֵ = Ŀ��ֵ
        //      Ϊfalese������ľ���Ŀ��ֵ��������ֵ = Ŀ��ֵ


        //10�����ö�����֡����
        //���磺
        //    Target.DOMove(Vector3.one, 2).SetUpdate(UpdateType.Normal, true);
        //��һ������ UpdateType :ѡ��ʹ�õ�֡����
        //    UpdateType.Normal:����ÿһ֡�и���Ҫ�� 
        //    UpdateType.Late:��LateUpdate�����ڼ����ÿһ֡�� 
        //    UpdateType.Fixed:ʹ��FixedUpdate���ý��и��¡� 
        //    UpdateType.Manual:ͨ���ֶ�DOTween.ManualUpdate���ý��и��¡�
        //�ڶ���������ΪTRUE���򲹼佫����Unity��Time.timeScale
    }
    #endregion

    #region Ease �˶����ߵ�����
    private void SettingForEaseMove()
    {
        //1����Easeö����Ϊ����
        //  ���磺
        //  Target.DOMove(Vector3.one, 2).SetEase(Ease.Flash, 3, 0f);
        //�ڶ������� Amplitude(���)��ʵ�ʾ����ƶ���������ʼ���ƶ���Ŀ�����ƶ�һ�Σ����ƶ������ƶ�����
        //���������� period ֵ�ķ�Χ�� -1~1
        //  ֵ > 0ʱ��Ϊ���Χ��˥��ֵ�����Χ���ɴ��С
        //  ֵ = 0ʱ�����Ǿ��ȵ�����ʼ�����Ŀ������֮���˶�
        //  ֵ < 0ʱ����ʩ��һ����Ŀ�������һ���������Χһ����������ƽ�Ŀ���
        // ����������ֻ��Flash, InFlash, OutFlash, InOutFlash�������������ã����������������õľ�ֻ��Easeö�ٲ���

        //2��ʹ��AnimationCurve��������
        //  ���磺
        //   Target.DOMove(Vector3.one * 2, 1).SetEase(curve);
        //AnimationCurve ������ʱ��, �������Ǿ����ʱ�䣬����ʱ�����
        //AnimationCurve �����Ǳ���
        //���������ֵΪv������DOMove�ĵ�һ������endValue��e����ʼ��������s
        //��������󶯻�����ʱ��ʵ�����꼴Ϊ v * ��e - s��+s

        // 3���Իص�����Ϊ����
        //  ���磺
        //   Target.DOMove(Vector3.one * 2, 1).SetEase(MyEaseFun);
    }

    //����ֵ���˶�����İٷֱ� ֵӦΪ0~1֮�䣬����ֵ��Ϊ1,��Ȼͣ����λ�ò�����Ŀ��λ��
    private float MyEaseFun(float time, float duration, float overshootOrAmplitude, float period)
    {
        return time / duration;
    }
    #endregion

    #region �ص�����
    private void MoveCallBack()
    {
        //1��������ɻص�
        //Target.DOMove(Vector3.one, 2).OnComplete(() => { });

        //2��������ɱ��ʱ�ص�
        //Target.DOMove(Vector3.one, 2).OnKill(() => { });

        //3����������ʱ�ص�,��ͣ�����²���Ҳ�����
        //Target.DOMove(Vector3.one, 3).OnPlay(() => { });

        //4��������ͣʱ�ص�
        //Target.DOMove(Vector3.one, 2).OnPause(() => { });

        //5����������ʱ�ص�
        //  ��������ᱻ����
        //ʹ��DORestart���²���ʱ
        //ʹ��Rewind�����������ʱ
        //ʹ��DOFlip��ת�������ʱ
        //ʹ��DOPlayBackwards���򲥷Ŷ������ʱ
        //Target.DOMove(Vector3.one, 2).OnRewind(() => { });

        //6��ֻ�ڵ�һ�β��Ŷ���ʱ���ã���play֮ǰ����
        //Target.DOMove(Vector3.one, 2).OnStart(() => { });

        //7����ɵ���ѭ������ʱ����
        //Target.DOMove(Vector3.one, 2).OnStepComplete(() => { });
        //8��֡�ص�
        //Target.DOMove(Vector3.one, 2).OnUpdate(() => { });

        //9����·������ʱ���ı�Ŀ���ʱ�Ļص�������Ϊ��ǰĿ�����±�
        //Target.DOMove(Vector3.one, 2).OnWaypointChange((value) => { });
    }
    #endregion

    #region �������Ʒ���
    private void AnimatorControl()
    {
        //1)����
        //Target.DOPlay();

        //2)��ͣ
        //Target.DOPause();

        //3)�ز�
        //Target.DORestart();

        //4)�������˷�����ֱ���˻���ʼ��
        //Target.DORewind();

        //5)ƽ���������˷����ᰴ��֮ǰ���˶���ʽ�ӵ�ǰλ���˻���ʼ��
        //Target.DOSmoothRewind();

        //6)ɱ������
        //Target.DOKill();

        //7)��ת����ķ���
        //Target.DOFlip();

        //8)��תʱ���
        //  ��һ��������ת��ʱ��㣬�ڶ�����������ת���Ƿ񲥷Ŷ���
        //Target.DOGoto(1.5f, true);

        //9�����򲥷Ŷ���
        //  ���򲥷Ŷ������ڶ������ŵ�һ��ʱִ�У����˻���ʼ�㣬��һ��ʼִ�п�����Ч������Ϊ�����屾�������ʼ��
        //Target.DOPlayBackwards();

        //10�����򲥷Ŷ���
        //  ���򲥷Ŷ���
        //Target.DOPlayForward();

        //11��TogglePause
        //  ����ͣʱ��ִ�оͼ������ţ�����ʱ��ִ�о���ͣ
        //Target.DOTogglePause();
    }
    #endregion

    #region ��ȡ���ݷ���
    private void GetDataFunction()
    {
        #region �෽��
        //  1������������ͣ�Ķ�����û���򷵻�null
        //  DOTween.PausedTweens();

        //  2�����������������ŵĶ�����û���򷵻�null
        //  DOTween.PlayingTweens();

        //  3����ȡ����ID������
        //   ���磺
        //  DOTween.TweensById("id", true);
        //  �������������Ķ�������
        //  ��һ�������Ƕ�����ID
        //  �ڶ����������Ƿ�ֻ�ռ����ڲ��ŵĶ���


        //  4�����ظ������������
        //   ���磺
        //  DOTween.TweensByTarget(transform, true);
        //  �������������Ķ�������
        //  ��һ�������ǲ��Ŷ����Ķ���
        //   ���磺
        //  transform.DOMove(Vector3.one, 2); ��һ�������ʹ���transform
        //  material.DOColor(Color.White, 2); ��һ�������ʹ�����ʶ���material
        //  �ڶ����������Ƿ�ֻ�ռ����ڲ��ŵĶ���


        //5���ռ�����Ķ����Ƿ��ж����ڻ
        // ���磺
        // DOTween.IsTweening(transform);
        //  ��һ������Ϊ���Ķ���
        //  �ڶ�������Ϊ�Ƿ��⶯���ڲ���״̬
        //   Ϊtrueʱ�����������ڲ���״̬ʱ ����true
        //   Ϊfalseʱ��ֻ�����������Ƿ��ж�������pause״̬ʱҲ�㣩���򷵻�true


        //6�����ڲ��ŵĶ�����������Ŀǰ�����ӳٲ���״̬�Ķ���Ҳ��
        //  DOTween.TotalPlayingTweens();
        #endregion

        #region ʵ������
        //  _tweener = transform.DOMove(Vector3.one, 2)

        //  1����ʾ����ִ��ʱ������ԣ��ɶ���д
        //  _tweener.fullPosition = 1;

        //  2����ʾ����ִ����Ĵ���
        // _tweener.CompletedLoops()


        //  3����ȡ�������ӳ�ʱ��
        //  _tweener.Delay();

        //  4����ȡ�����ĳ���ʱ��
        //    ����Ϊtrue ��ʾ����ѭ����ʱ�䣬����ѭ��ΪInfinity
        //  _tweener.Duration(false)


        //  5�������Ѳ��ŵ�ʱ��
        //  ����Ϊtrue ��ʾ����ѭ����ʱ��
        //  _tweener.Elapsed()


        //  6�����ض������ȵİٷֱ�
        //  ��ʼ��Ϊ0 Ŀ���Ϊ1 ��yoyoѭ��ģʽ�£�ֵ���0�䵽1�ٴ�1�䵽0
        //  _tweener.ElapsedDirectionalPercentage()


        //  7�����ض����������õİٷֱ�
        //  ����ѭ������ֵΪ0��1
        //  ����Ϊ �Ƿ����ѭ�� Ϊtrueʱ ����ֵ��ѭ������������ðٷֱ� ��Ϊ����ѭ�� ����ֵΪ0
        //  _tweener.ElapsedPercentage(true)


        //  8�������Ƿ��ڻ
        //  _tweener.IsActive();

        //  9���Ƿ��Ƿ��򶯻�
        //  _tweener.IsBackwards();

        //  10�������Ƿ����
        //  _tweener.IsComplete();

        //  11���Ƿ��Գ�ʼ��
        //  _tweener.IsInitialized();

        //  12���Ƿ����ڲ���
        //  _tweener.IsPlaying();

        //  13������ѭ��������  ����ѭ��ΪInfinity
        //  _tweener.Loops();
        #endregion
    }
    #endregion

    #region Я�̷���
    public IEnumerator Wait()
    {
        //1)�ȴ�����ִ����
        //yield return _tweener.WaitForCompletion();

        //2���ȴ�ָ����ѭ������
        //  ����Ϊִ�д������ȴ������ѭ�������󣬼���ִ��
        //  ���Ǵ���Ĵ������ڶ�����ѭ������ ���ڶ�������ʱ����ִ��
        //yield return _tweener.WaitForElapsedLoops(2);

        //3���ȴ�������ɱ��
        //yield return _tweener.WaitForKill();

        //4���ȴ�����ִ��ָ��ʱ��
        //  ����Ϊʱ�䣬����ִ�д����ʱ��֮��򶯻�ִ����ϣ�����ִ��
        //yield return _tweener.WaitForPosition(0.5f);

        //5���ȴ���������
        //  ������������ִ�к���
        //ʹ��DORestart���²���ʱ
        //ʹ��Rewind�����������ʱ
        //ʹ��DOFlip��ת�������ʱ
        //ʹ��DOPlayBackwards���򲥷Ŷ������ʱ
        //yield return _tweener.WaitForRewind();

        //6���ȴ�Startִ�к����ִ��
        yield return _tweener.WaitForStart();
    }
    #endregion
}
