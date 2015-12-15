﻿using System;
using System.Collections.Generic;


namespace Nez
{
	public class EntityProcessor
	{
		protected Matcher _matcher;
		public Matcher matcher
		{
			get { return _matcher; }
		}

		protected List<Entity> _entities = new List<Entity>();

		protected Scene _scene;
		public Scene scene 
		{
			get { return _scene; }
			set 
			{
				_scene = value;
				_entities = new List<Entity>();
			}
		}

		public EntityProcessor(Matcher matcher)
		{
			_matcher = matcher;
		}

		public virtual void onChange(Entity entity) 
		{
			bool contains = _entities.Contains( entity );
			bool interest = _matcher.isInterested( entity );

			if (interest && !contains)
			{
				Add(entity);
			}
			else if (!interest && contains)
			{
				Remove(entity);
			}
		}

		public virtual void Add(Entity entity) 
		{
			_entities.Add( entity );
			onAdded( entity );
		}

		public virtual void Remove(Entity entity) 
		{
			_entities.Remove( entity );
			onRemoved( entity );
		}

		public virtual void onAdded( Entity entity )
		{
		}

		public virtual void onRemoved( Entity entity )
		{
		}

		protected virtual void process(List<Entity> entities)
		{
		}

		public virtual void begin()
		{
		}

		public virtual void update()
		{
			begin();
			process(_entities);
			end();
		}

		public virtual void end()
		{
		}
	}
}

