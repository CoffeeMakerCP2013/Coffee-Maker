namespace EyeSoft.ServiceModel
{
	using System;
	using System.ServiceModel;

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	internal class MessageHeaderAttribute
		: MessageContractMemberAttribute
	{
		private bool mustUnderstand;
		private bool relay;

		public bool MustUnderstand
		{
			get
			{
				return mustUnderstand;
			}

			set
			{
				mustUnderstand = value;
				IsMustUnderstandSet = true;
			}
		}

		public bool Relay
		{
			get
			{
				return relay;
			}

			set
			{
				relay = value;
				IsRelaySet = true;
			}
		}

		public string Actor { get; set; }

		internal bool IsMustUnderstandSet { get; private set; }

		internal bool IsRelaySet { get; private set; }
	}
}